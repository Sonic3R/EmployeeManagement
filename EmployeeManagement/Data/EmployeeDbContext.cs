using EmployeeManagement.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EmployeeDbContext : IdentityDbContext<WebUser>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<Personna> Personna { get; set; }

        public DbSet<Departments> Departments { get; set; }

        public DbSet<Positions> Positions { get; set; }
    }
}
