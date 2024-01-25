using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using MovieSharing.Data;
using MovieSharing.Models;
using VideotheekWebApp.Models;

namespace MovieSharing.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class ReservatiesController : Controller
    {
        private readonly MovieSharingDBContext _context;

        private readonly IStringLocalizer<ReservatiesController> _localizer;

        public ReservatiesController(MovieSharingDBContext context, IStringLocalizer<ReservatiesController> localizer)
        {
            _context = context;

            _localizer = localizer;
        }

        // GET: Reservaties
        public async Task<IActionResult> Index(String searchString)
        {
            var userid = User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Lid user = _context.Users.Where(a => a.Id == userid).Single();

            if (User.IsInRole("admin"))
            {
                ViewData["CurrentFilter"] = searchString;

                if (!string.IsNullOrEmpty(searchString))
                {
                    var movieSharingDBContext = _context.Reservatie.Include(r => r.film)
                        .Include(r => r.lid)
                        .Where(r => r.film.Title.Contains(searchString) && r.Deleted == false);

                    return View(await movieSharingDBContext.ToListAsync());
                }
                else
                {
                    var movieSharingDBContext = _context.Reservatie.Include(r => r.film).Include(r => r.lid).Where(c => c.Deleted == false);
                    return View(await movieSharingDBContext.ToListAsync());
                }
            }
            else
            {
                var movieSharingDBContext = _context.Reservatie.Include(r => r.film).Include(r => r.lid).
                        Where(c => c.LidId == user.Id && c.Deleted == false);

                return View(await movieSharingDBContext.ToListAsync());
            }
        }

        // GET: Reservaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservatie == null)
            {
                return NotFound();
            }

            var reservatie = await _context.Reservatie
                .Include(r => r.film)
                .Include(r => r.lid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservatie == null)
            {
                return NotFound();
            }

            return View(reservatie);
        }

        // GET: Reservaties/Create
        public IActionResult Create()
        {

            if (User.IsInRole("admin"))
            {
                var leden = _context.Users.ToList().Where(c => c.Id == User?.FindFirstValue(ClaimTypes.NameIdentifier));
                var films = _context.Films.ToList().Where(c => c.Deleted == false);
                ViewData["FilmTitle"] = new SelectList(films, "Id", "Title");
                ViewData["LidName"] = new SelectList(_context.Users, "Id", "UserName");
            }
            else
            {
                var leden = _context.Users.ToList().Where(c => c.Id == User?.FindFirstValue(ClaimTypes.NameIdentifier));
                var films = _context.Films.ToList().Where(c => c.Deleted == false);
                ViewData["FilmTitle"] = new SelectList(films, "Id", "Title");
                ViewData["LidName"] = new SelectList(leden, "Id", "UserName");
            }

            return View();
        }

        // POST: Reservaties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LidId,FilmId,Deleted")] Reservatie reservatie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservatie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Id", reservatie.FilmId);
            ViewData["LidId"] = new SelectList(_context.Users, "Id", "Id", reservatie.LidId);
            return View(reservatie);
        }

        // GET: Reservaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservatie == null)
            {
                return NotFound();
            }

            var reservatie = await _context.Reservatie.FindAsync(id);
            if (reservatie == null)
            {
                return NotFound();
            }


            if (User.IsInRole("admin"))
            {
                var leden = _context.Users.ToList().Where(c => c.Id == User?.FindFirstValue(ClaimTypes.NameIdentifier));
                var films = _context.Films.ToList().Where(c => c.Deleted == false);
                ViewData["FilmTitle"] = new SelectList(films, "Id", "Title");
                ViewData["LidName"] = new SelectList(_context.Users, "Id", "UserName");
            }
            else
            {
                var leden = _context.Users.ToList().Where(c => c.Id == User?.FindFirstValue(ClaimTypes.NameIdentifier));
                var films = _context.Films.ToList().Where(c => c.Deleted == false);
                ViewData["FilmTitle"] = new SelectList(films, "Id", "Title");
                ViewData["LidName"] = new SelectList(leden, "Id", "UserName");
            }

            return View(reservatie);
        }

        // POST: Reservaties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LidId,FilmId,Deleted")] Reservatie reservatie)
        {
            if (id != reservatie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservatieExists(reservatie.Id))
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
            ViewData["FilmId"] = new SelectList(_context.Films, "Id", "Id", reservatie.FilmId);
            ViewData["LidId"] = new SelectList(_context.Users, "Id", "Id", reservatie.LidId);
            return View(reservatie);
        }

        // GET: Reservaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservatie == null)
            {
                return NotFound();
            }

            var reservatie = await _context.Reservatie
                .Include(r => r.film)
                .Include(r => r.lid)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservatie == null)
            {
                return NotFound();
            }

            return View(reservatie);
        }

        // POST: Reservaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservatie == null)
            {
                return Problem("Entity set 'MovieSharingDBContext.Reservatie'  is null.");
            }
            var reservatie = await _context.Reservatie.FindAsync(id);
            if (reservatie != null)
            {
                reservatie.Deleted = true;
                //Zelfde als bij films, willen niet verwijderen
                //_context.Reservatie.Remove(reservatie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservatieExists(int id)
        {
          return (_context.Reservatie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
