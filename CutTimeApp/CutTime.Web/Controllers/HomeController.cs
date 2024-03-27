using CutTime.Domain.Contracts;
using CutTime.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CutTime.Web.Controllers
{
    [Authorize(Roles = "Administrador,Cliente,Barbero")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryWrapper repositoryWrapper;

        public HomeController(ILogger<HomeController> logger, IRepositoryWrapper repositoryWrapper)
        {
            _logger = logger;
            this.repositoryWrapper = repositoryWrapper;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await repositoryWrapper.AppointmentRepository.FindAll();
            var barbers = await repositoryWrapper.BarberRepository.FindAll();
            var clients = await repositoryWrapper.ClientRepository.FindAll();

            ViewBag.Appointments = appointments.Count();
            ViewBag.Barbers = barbers.Count();
            ViewBag.Clients = clients.Count();
            return View();
        }

        [AllowAnonymous]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}