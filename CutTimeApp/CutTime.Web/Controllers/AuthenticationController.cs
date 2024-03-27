using CutTime.Domain.Models;
using CutTime.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CutTime.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User data)
        {

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {            
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
