using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CutTime.Web;
using CutTime.Web.Models;
using CutTime.Domain.Contracts;
using CutTime.Domain.Models;

namespace CutTime.Web.Controllers
{
    public class BarbersController : Controller
    {

        private readonly IRepositoryWrapper _Repository;

        public BarbersController(IRepositoryWrapper Repository)
        {
            _Repository = Repository;
        }

        // GET: Barbers
        public async Task<IActionResult> Index()
        {
            return View(await _Repository.BarberRepository.ToListAsync());
        }

        // GET: Barbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var barber = await _Repository.BarberRepository.FindByCondition(m => m.ID_Barber == id).FirstOrDefaultAsync();

            return barber == null ? NotFound() : View(barber);
        }

        // GET: Barbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Lastname,Email,Phone")] Barber barber)
        {
            
            if (ModelState.IsValid || ModelState.ErrorCount == 2)
            {
                barber.ID_User = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
                _Repository.BarberRepository.Create(barber);

                await _Repository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(barber);
        }

        // GET: Barbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var barber = await _Repository.BarberRepository.FindByConditionAsync(x=> x.ID_Barber == id);
            return barber == null ? NotFound() : View(barber.FirstOrDefault());

        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarber, Name,Lastname,Email,Phone")] Barber barber)
        {
 
            if (ModelState.IsValid || ModelState.ErrorCount == 2)
            {
                try
                {
                    barber.ID_Barber = id;
                    barber.ID_User = HttpContext.Session.GetInt32("UsuarioId") ?? 0;
                    _Repository.BarberRepository.Update(barber);
                    await _Repository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberExists(barber.ID_Barber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(barber);
        }

        // GET: Barbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var barber = await _Repository.BarberRepository.FindByConditionAsync(m => m.ID_Barber == id);
            return barber == null ? NotFound() : View(barber.FirstOrDefault());
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barber = await _Repository.BarberRepository.FindByConditionAsync(m => m.ID_Barber == id);
            if (barber.FirstOrDefault() != null)
            {
                _Repository.BarberRepository.Delete(barber.First());
            }
            
            await _Repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberExists(int id)
        {
          return _Repository.BarberRepository.Any(e => e.ID_Barber == id);
        }
    }
}
