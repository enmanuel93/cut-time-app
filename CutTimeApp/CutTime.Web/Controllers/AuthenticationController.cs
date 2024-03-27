using CutTime.Domain.Models;
using CutTime.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CutTime.Web.Mocks;
using CutTime.Domain.Contracts;
using AutoMapper;
using CutTime.Web.DTOs;

namespace CutTime.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public AuthenticationController(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var userModel = await repositoryWrapper.UserRepository.GetUserAndRolByCredentials(user);

            var model = mapper.Map<LoginDto>(userModel);

            if (model != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.Name),
                    new Claim("Email", model.Email)
                };

                foreach (var rol in model.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol.Name));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
