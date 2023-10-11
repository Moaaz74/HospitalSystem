using Microsoft.AspNetCore.Mvc;

namespace HospitalSystem.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
