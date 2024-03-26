using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using CutTime.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers
{

    public class AuthenticationController : Controller
    {

        private readonly IRepositoryWrapper _Repository;

        public AuthenticationController(IRepositoryWrapper Repository) {
            _Repository = Repository;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginView LoginView) {

            var Usuarios = _Repository.UserRepository.FindByCondition(x => x.Email == LoginView.email);

            if (LoginView.email is null or "") { }
            else if (LoginView.password is null or "") { }
            else if (!Usuarios.Any()) { }
            else if (LoginView.password != Usuarios.First().Password) { }
            else {

                var Usuario = Usuarios.First();
                HttpContext.Session.SetInt32("UsuarioId", Usuario.ID_User);
                HttpContext.Session.SetString("UsuarioNombre", $"{Usuario.Name} {Usuario.Lastname}".Trim());
                HttpContext.Session.SetString("UsuarioRol", Usuario.User_Type?.ToString() ?? "");
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Nombre de usuario o contraseña incorrectos";
            return View();
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterView RegisterView) {

            var Usuarios = _Repository.UserRepository.FindByCondition(x => x.Email == RegisterView.Email);

            if (RegisterView.Nombre is null or "") { ViewBag.Error = "Debe llenar los campos obligatorios."; }
            else if (RegisterView.Apellido is null or "") { ViewBag.Error = "Debe llenar los campos obligatorios."; } 
            else if (RegisterView.Contrasena is null or "") { ViewBag.Error = "Debe llenar los campos obligatorios."; }
            else if (Usuarios.Any()) { ViewBag.Error = "Ya existe un usuario con este corrreo electronico."; } 
            else {

                _Repository.UserRepository.Create(new User {
                    Name = RegisterView.Nombre,
                    Lastname = RegisterView.Apellido,
                    Password = RegisterView.Contrasena,
                    Email = RegisterView.Email,
                    User_Type = "Cliente"
                });

                _Repository.Save();

                return RedirectToAction("Login", "");
            }
                        
            return View();
        }

    }

}
