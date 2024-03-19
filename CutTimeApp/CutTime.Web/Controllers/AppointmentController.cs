using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
