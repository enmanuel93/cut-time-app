using CutTime.Web.ViewModel;

using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers {

    public class AuthenticationController : Controller
    {

        private readonly CutTimeContext _Contexto;

        public AuthenticationController(CutTimeContext Contexto) {
            _Contexto = Contexto;

        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginView LoginView) {

            var Usuarios = _Contexto.Users.Where(x => x.Email == LoginView.email);

            if (LoginView.email is null or "") { }
            else if (LoginView.password is null or "") { }
            else if (!Usuarios.Any()) { }
            else if (LoginView.password != Usuarios.First().Password) { }
            else {

                var Usuario = Usuarios.First();
                HttpContext.Session.SetString("UsuarioId", Usuario.IdUser.ToString());
                HttpContext.Session.SetString("UsuarioNombre", $"{Usuario.Name} {Usuario.Lastname}".Trim());
                HttpContext.Session.SetString("UsuarioRol", Usuario.UserType?.ToString() ?? "");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterView RegisterView) {

            var Usuarios = _Contexto.Users.Where(x => x.Email == RegisterView.Email);

            if (RegisterView.Nombre is null or "") { ViewBag.Error = "Debe llenar los campos obligatorios."; }
            else if (RegisterView.Apellido is null or "") { ViewBag.Error = "Debe llenar los campos obligatorios."; } 
            else if (RegisterView.Contrasena is null or "") { ViewBag.Error = "Debe llenar los campos obligatorios."; }
            else if (Usuarios.Any()) { ViewBag.Error = "Ya existe un usuario con este corrreo electronico."; } 
            else {

                _Contexto.Users.Add(new Models.User {
                    IdUser = _Contexto.Users.Count() + 1,
                    Name = RegisterView.Nombre,
                    Lastname = RegisterView.Apellido,
                    Password = RegisterView.Contrasena,
                    Email = RegisterView.Email,
                    UserType = "Cliente"
                });

                _Contexto.SaveChanges();

                return RedirectToAction("Login", "");
            }
                        
            return View();
        }

    }

}
