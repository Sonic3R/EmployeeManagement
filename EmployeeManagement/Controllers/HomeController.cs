using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private EmployeeDbContext _context;
        
        public HomeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Title = "Index 1";
            model.Items = _context.Personna.Include(dep => dep.Department).Include(pos => pos.Position).ToList();

            return View("Index", model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
