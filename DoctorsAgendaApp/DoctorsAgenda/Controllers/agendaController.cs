using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorsAgenda.Data;
using DoctorsAgenda.Models;

namespace DoctorsAgenda.Controllers
{
    public class agendaController : Controller
    {
        private readonly DocAgendaContext _context;

        public agendaController(DocAgendaContext context)
        {
            _context = context;
        }

        // GET: agenda
        public async Task<IActionResult> Index()
        {
            var docAgendaContext = _context.Agenda.Include(a => a.User);
            return View(await docAgendaContext.ToListAsync());
        }

        // GET: agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: agenda/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AgendaId,AgendasName,UserId")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agenda.UserId);
            return View(agenda);
        }

        // GET: agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agenda.UserId);
            return View(agenda);
        }

        // POST: agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AgendaId,AgendasName,UserId")] Agenda agenda)
        {
            if (id != agenda.AgendaId)
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
                    if (!AgendaExists(agenda.AgendaId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", agenda.UserId);
            return View(agenda);
        }

        // GET: agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agenda
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AgendaId == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agenda.FindAsync(id);
            _context.Agenda.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaExists(int id)
        {
            return _context.Agenda.Any(e => e.AgendaId == id);
        }
    }
}
