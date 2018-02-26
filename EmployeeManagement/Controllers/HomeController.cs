using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeDAL.Personna;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IPersonnaDAL _personnaDAL;

        public HomeController(IPersonnaDAL personnaDAL)
        {
            _personnaDAL = personnaDAL;
        }

        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Items = _personnaDAL.List();

            return View("Index", model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
