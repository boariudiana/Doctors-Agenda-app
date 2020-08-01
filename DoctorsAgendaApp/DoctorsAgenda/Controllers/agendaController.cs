using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorsAgenda.Areas.Identity.Data;
using DoctorsAgenda.Models;

namespace DoctorsAgenda.Controllers
{
    public class agendaController : Controller
    {
        private readonly DoctorsAgendaContext _context;

        public agendaController(DoctorsAgendaContext context)
        {
            _context = context;
        }

        // GET: agenda
        public async Task<IActionResult> Index()
        {
            var doctorsAgendaContext = _context.Agenda.Include(a => a.User);
            return View(await doctorsAgendaContext.ToListAsync());
        }

        // GET: agenda/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.DoctorName == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: agenda/Create
        public IActionResult Create()
        {
            ViewData["EmailRef"] = new SelectList(_context.Users, "Email", "Id");
            return View();
        }

        // POST: agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorName,EmailRef")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmailRef"] = new SelectList(_context.Users, "Email", "Id", agenda.EmailRef);
            return View(agenda);
        }

        // GET: agenda/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda.FindAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }
            ViewData["EmailRef"] = new SelectList(_context.Users, "Email", "Id", agenda.EmailRef);
            return View(agenda);
        }

        // POST: agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DoctorName,EmailRef")] Agenda agenda)
        {
            if (id != agenda.DoctorName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.DoctorName))
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
            ViewData["EmailRef"] = new SelectList(_context.Users, "Email", "Id", agenda.EmailRef);
            return View(agenda);
        }

        // GET: agenda/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.DoctorName == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var agenda = await _context.Agenda.FindAsync(id);
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(string id)
        {
            return _context.Agenda.Any(e => e.DoctorName == id);
        }
    }
}
