using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers
{
    public class BarbersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
