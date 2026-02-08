using System.Diagnostics;
using EmployeeTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

    }
}
