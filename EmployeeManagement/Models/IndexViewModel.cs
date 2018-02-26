using EmployeeTL;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public sealed class IndexViewModel : PageViewModel
    {
        public List<PersonnaTL> Items { get; set; }
    }
}
