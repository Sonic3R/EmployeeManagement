using System.Collections.Generic;
using System.Data.SqlClient;
using EmployeeTL;
using Microsoft.Extensions.Configuration;

namespace EmployeeDAL.Personna
{
    public sealed class PersonnaDAL : IPersonnaDAL
    {
        private IConfiguration _configuration;
        private const string LIST_PROC_NAME = "ListPeople";
        private const string GET_PROC_NAME = "GetPersonna";

        public PersonnaDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PersonnaTL Get(int id)
        {
            using (DbInterogator interogator = new DbInterogator(_configuration))
            {
                interogator.SetStoredProcedureWithParams(LIST_PROC_NAME, new Dictionary<string, object> { { "id", id } });

                using (var sqlReader = interogator.Execute())
                {
                    PersonnaTL item = new PersonnaTL();

                    if (sqlReader.Read())
                    {
                        item = ToObject(sqlReader);
                    }

                    return item;
                }
            }
        }

        public List<PersonnaTL> List()
        {
            using(DbInterogator interogator = new DbInterogator(_configuration))
            {
                interogator.SetStoredProcedureWithParams(LIST_PROC_NAME, null);

                using(var sqlReader = interogator.Execute())
                {
                    List<PersonnaTL> list = new List<PersonnaTL>();

                    while(sqlReader.Read())
                    {
                        list.Add(ToObject(sqlReader));
                    }

                    return list;
                }
            }
        }

        private PersonnaTL ToObject(SqlDataReader sqlReader)
        {
            return new PersonnaTL
            {
                Id = sqlReader.GetInt32(0),
                FirstName = sqlReader.GetString(1),
                LastName = sqlReader.GetString(2),
                Mobile = sqlReader.GetString(3),
                Email = sqlReader.GetString(4),
                UserName = sqlReader.GetString(5),
                PhoneExt = sqlReader.GetInt32(6),
                Info = sqlReader.GetString(7),
                IsAdmin = sqlReader.GetBoolean(10),
                Department = new DepartmentsTL
                {
                    Id = sqlReader.GetInt32(12),
                    Name = sqlReader.GetString(13)
                },
                Position = new PositionsTL
                {
                    Id = sqlReader.GetInt32(14),
                    Name = sqlReader.GetString(15)
                }
            };
        }
    }
}
