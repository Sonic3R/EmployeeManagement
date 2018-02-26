using EmployeeManagement.Configs;
using EmployeeManagement.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Data
{
    public class EmployeeSeeder
    {
        private EmployeeDbContext _ctx;
        private UserManager<WebUser> _manager;
        private IOptions<AppSettings> _settings;

        public EmployeeSeeder(EmployeeDbContext ctx, UserManager<WebUser> manager, IOptions<AppSettings> settings)
        {
            _ctx = ctx;
            _manager = manager;
            _settings = settings;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            var user = await _manager.FindByEmailAsync(_settings.Value.AdminEmail);
            if(user == null)
            {
                user = new WebUser
                {
                    FirstName = _settings.Value.AdminFirstName,
                    LastName = _settings.Value.AdminLastName,
                    Email = _settings.Value.AdminEmail,
                    UserName = _settings.Value.AdminUserName
                };

                var result = await _manager.CreateAsync(user, _settings.Value.AdminPassword);

                if(!result.Succeeded)
                {
                    throw new Exception("Cannot create user");
                }
            }
        }
    }
}
