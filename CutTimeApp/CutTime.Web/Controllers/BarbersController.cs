using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CutTime.Web;
using CutTime.Web.Models;

namespace CutTime.Web.Controllers
{
    public class BarbersController : Controller
    {
        private readonly CutTimeContext _context;

        public BarbersController(CutTimeContext context)
        {
            _context = context;
        }

        // GET: Barbers
        public async Task<IActionResult> Index()
        {
            var cutTimeContext = _context.Barbers.Include(b => b.IdUserNavigation);
            return View(await cutTimeContext.ToListAsync());
        }

        // GET: Barbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Barbers == null) return NotFound();

            var barber = await _context.Barbers.FirstOrDefaultAsync(m => m.IdBarber == id);

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
            if (ModelState.IsValid)
            {
                barber.IdBarber = (_context.Barbers.Max(b => (int?)b.IdBarber) ?? 0) + 1;
                barber.IdUser = HttpContext.Session.GetInt32("UsuarioId");
                _context.Add(barber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(barber);
        }

        // GET: Barbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Barbers == null)
            {
                return NotFound();
            }

            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
            {
                return NotFound();
            }
            ViewData["IdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", barber.IdUser);
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarber, Name,Lastname,Email,Phone")] Barber barber)
        {
 
            if (ModelState.IsValid)
            {
                try
                {
                    barber.IdBarber = id;
                    barber.IdUser = HttpContext.Session.GetInt32("UsuarioId");
                    _context.Update(barber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarberExists(barber.IdBarber))
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
            if (id == null || _context.Barbers == null)
            {
                return NotFound();
            }

            var barber = await _context.Barbers
                .Include(b => b.IdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdBarber == id);
            if (barber == null)
            {
                return NotFound();
            }

            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Barbers == null)
            {
                return Problem("Entity set 'CutTimeContext.Barbers'  is null.");
            }
            var barber = await _context.Barbers.FindAsync(id);
            if (barber != null)
            {
                _context.Barbers.Remove(barber);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarberExists(int id)
        {
          return (_context.Barbers?.Any(e => e.IdBarber == id)).GetValueOrDefault();
        }
    }
}
