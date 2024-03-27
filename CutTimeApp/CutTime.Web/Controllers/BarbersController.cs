using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class BarbersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
