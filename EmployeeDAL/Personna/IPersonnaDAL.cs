using EmployeeTL;
using System.Collections.Generic;

namespace EmployeeDAL.Personna
{
    public interface IPersonnaDAL
    {
        List<PersonnaTL> List();

        PersonnaTL Get(int id);
    }
}
