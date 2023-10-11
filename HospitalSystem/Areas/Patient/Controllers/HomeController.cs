using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Areas.Patient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
