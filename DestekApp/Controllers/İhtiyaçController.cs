using DestekApp.Data;
using DestekApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DestekApp.Controllers
{
    public class İhtiyaçController : Controller
    {
        //dependency  ınjection  bagımlılıkları ortadan kaldırma...
        private readonly DestekAppDBContext _context;

        public İhtiyaçController(DestekAppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            IEnumerable<İhtiyaç> ihtiyaçlarım = await _context.İhtiyaçlar.Include(a=>a.Frekans).Where(a => a.KullanıcıID == sidd).OrderByDescending(a=>a.İhtiyaçID).ToListAsync();


            ViewData["Benimİhtiyaçlarım"] = new SelectList(_context.Frekanslar, "FrekansID", "FrekansAdı");
            return View(ihtiyaçlarım);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("İhtiyaçAdı,İhtiyaçAçıklama,FrekansID")] İhtiyaç ihtiyaç)
        {
            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            ihtiyaç.KullanıcıID = sidd;
            ihtiyaç.KayıtTarihi=DateTime.Now;
            IEnumerable<İhtiyaç> ihtiyaçlarım;
            if (ModelState.IsValid)
            {
                _context.Add(ihtiyaç);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "İhtiyaç başarıyla kaydedildi";

                ViewData["Benimİhtiyaçlarım"] = new SelectList(_context.Frekanslar, "FrekansID", "FrekansAdı");
                ihtiyaçlarım = await _context.İhtiyaçlar.Include(a => a.Frekans).Where(a => a.KullanıcıID == sidd).OrderByDescending(a => a.İhtiyaçID).ToListAsync();
                return View(ihtiyaçlarım);
            }
            ViewData["Benimİhtiyaçlarım"] = new SelectList(_context.Frekanslar, "FrekansID", "FrekansAdı");
            ihtiyaçlarım = await _context.İhtiyaçlar.Include(a => a.Frekans).Where(a => a.KullanıcıID == sidd).OrderByDescending(a => a.İhtiyaçID).ToListAsync();
            return View(ihtiyaçlarım);

        }
    }
}
