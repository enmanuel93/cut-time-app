using CutTime.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers
{
    public class AuthenticationController : Controller
    {

        private CutTimeContext _Contexto;

        public AuthenticationController(CutTimeContext Contexto) {
            _Contexto = Contexto;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginView data)
        {

            var VarUsuarios = _Contexto.Users.Where(x => x.Email == data.email && x.Password == data.password);

            if (data.email is null or "") { }
            else if (data.password is null or "") { }
            else if (!VarUsuarios.Any()) { }
            else {

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
