using EmployeeManagement.Data.Entities;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public sealed class IndexViewModel : PageViewModel
    {
        public List<Personna> Items { get; set; }
    }
}
