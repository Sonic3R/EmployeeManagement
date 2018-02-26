using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Data.Entities
{
    public class WebUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
