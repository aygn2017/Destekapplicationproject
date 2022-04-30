using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DestekApp.Data;
using DestekApp.Models;

namespace DestekApp.Controllers
{
    public class KullanıcıController : Controller
    {
        private readonly DestekAppDBContext _context;

        public KullanıcıController(DestekAppDBContext context)
        {
            _context = context;
        }

        // GET: Kullanıcı
        public async Task<IActionResult> Index()
        {
            var destekAppDBContext = _context.Kullanıcılar.Include(k => k.Rol);
            return View(await destekAppDBContext.ToListAsync());
        }

        // GET: Kullanıcı/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.KullanıcıID == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // GET: Kullanıcı/Create
        public IActionResult Create()
        {
            ViewData["RolID"] = new SelectList(_context.Roller, "RolID", "RolAdı");
            return View();
        }

        // POST: Kullanıcı/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullanıcıID,Eposta,Şifre,RolID")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanıcı);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RolID"] = new SelectList(_context.Roller, "RolID", "RolAdı", kullanıcı.RolID);
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar.FindAsync(id);
            if (kullanıcı == null)
            {
                return NotFound();
            }
            ViewData["RolID"] = new SelectList(_context.Roller, "RolID", "RolAdı", kullanıcı.RolID);
            return View(kullanıcı);
        }

        // POST: Kullanıcı/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullanıcıID,Eposta,Şifre,RolID")] Kullanıcı kullanıcı)
        {
            if (id != kullanıcı.KullanıcıID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanıcı);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanıcıExists(kullanıcı.KullanıcıID))
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
            ViewData["RolID"] = new SelectList(_context.Roller, "RolID", "RolAdı", kullanıcı.RolID);
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar
                .Include(k => k.Rol)
                .FirstOrDefaultAsync(m => m.KullanıcıID == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // POST: Kullanıcı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullanıcı = await _context.Kullanıcılar.FindAsync(id);
            _context.Kullanıcılar.Remove(kullanıcı);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanıcıExists(int id)
        {
            return _context.Kullanıcılar.Any(e => e.KullanıcıID == id);
        }
    }
}
