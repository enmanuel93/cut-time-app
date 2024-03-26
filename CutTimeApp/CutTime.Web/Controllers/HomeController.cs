using CutTime.Domain.Contracts;
using CutTime.Web.Models;

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CutTime.Web.Controllers {

    public class HomeController : Controller {

        private readonly IRepositoryWrapper _Repository;

        public HomeController(IRepositoryWrapper Repository) {
            _Repository = Repository;

        }

        public IActionResult Index() {
            ViewBag.Barberos = _Repository.BarberRepository.Count();
            return View();
        }
        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }
}