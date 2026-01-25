using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrack.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
