using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDAL
{
    internal sealed class DbInterogator : IDisposable
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        public DbInterogator(IConfiguration config)
        {
            _sqlConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
            _sqlConnection.StateChange += StateDbChanged;
            _sqlConnection.Open();

            _sqlCommand = _sqlConnection.CreateCommand();
            _sqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public void SetStoredProcedureWithParams(string spName, Dictionary<string, object> dict )
        {
            if(string.IsNullOrWhiteSpace(spName))
            {
                throw new ArgumentNullException(nameof(spName));
            }

            _sqlCommand.CommandText = spName;

            if(dict != null && dict.Count > 0)
            {
                foreach(var kvp in dict)
                {
                    _sqlCommand.Parameters.Add(new SqlParameter("@" + kvp.Key.TrimStart('@'), kvp.Value));
                }
            }
        }

        public SqlDataReader Execute()
        {
            return _sqlCommand.ExecuteReader();
        }

        public void Dispose()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
            }
        }

        private void StateDbChanged(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Closed)
            {
                try
                {
                    _sqlConnection.Close();
                }
                finally
                {
                }
            }
        }
    }
}
