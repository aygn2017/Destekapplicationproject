using DestekApp.Data;
using DestekApp.Models;
using DestekApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DestekApp.Controllers
{
    [Authorize(Roles = "UserNormal")]
    public class ProfilController : Controller
    {
        
        //dependency  ınjection  bagımlılıkları ortadan kaldırma...
        private readonly DestekAppDBContext _context;

        public ProfilController(DestekAppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value); //bu çerezden gelen ben
            
            Kullanıcı kullanıcı = await _context.Kullanıcılar.Include(a => a.Kişi).ThenInclude(a=>a.Cinsiyet).Include(a => a.Adresler).Include(a => a.İletişimler).FirstOrDefaultAsync(a=>a.KullanıcıID == sidd);
            return View(kullanıcı);
        }
        public async Task<IActionResult> Adreslerim()
        {
            int sidd= Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            List<Adres> adreslerim = await _context.Adresler.Where(a => a.KullanıcıID == sidd).ToListAsync();
            return View(adreslerim);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adreslerim([Bind("AdresAdı,AdresBilgisi")] Adres adres)
        {

            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            IEnumerable<Adres> adreslerim;  

            adres.KullanıcıID= Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            if (ModelState.IsValid)
            {
                _context.Add(adres);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "Adresiniz başarıyla eklendi";


                adreslerim= await _context.Adresler.Where(a => a.KullanıcıID == sidd).ToListAsync();
                return View(adreslerim);
            }
            adreslerim = await _context.Adresler.Where(a => a.KullanıcıID == sidd).ToListAsync();
            return View(adreslerim);
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdresSil(int id)
        {

            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            Adres adres = await _context.Adresler.FindAsync(id);
            _context.Adresler.Remove(adres);
            await _context.SaveChangesAsync();

            IEnumerable<Adres> adreslerim =await _context.Adresler.Where(a => a.KullanıcıID == sidd).ToListAsync();
            return RedirectToAction("Adreslerim","Profil");
            
        }
        

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdresGüncelle([Bind("AdresAdı,AdresBilgisi")] Adres adres,int id)
        {

            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            adres.AdresID = id;
            adres.KullanıcıID= sidd;

            if (ModelState.IsValid)
            {
               _context.Update(adres);
               await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "Adres bilgileri başarıyla güncellendi.";
                return RedirectToAction("Adreslerim", "Profil");
            }
            return RedirectToAction("Adreslerim", "Profil");
        }


        public async Task<IActionResult> İletişim()
        {

            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            IEnumerable<İletişim> iletişimlerim =await _context.İletişimler.Where(a => a.KullanıcıID==sidd).OrderByDescending(a=>a.İletişimID).ToListAsync();
            return View(iletişimlerim);
            

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> İletişim([Bind("İletişimAdı,TelefonNo")] İletişim iletişim)
        {
            IEnumerable<İletişim> iletişimlerim;
            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            iletişim.KullanıcıID = sidd;
            if (ModelState.IsValid)
            {
                _context.Add(iletişim);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "İletişim bilgisi başarıyla eklendi";


                iletişimlerim = await _context.İletişimler.Where(a => a.KullanıcıID == sidd).OrderByDescending(a => a.İletişimID).ToListAsync();
                return View(iletişimlerim);
            }
            iletişimlerim = await _context.İletişimler.Where(a => a.KullanıcıID == sidd).OrderByDescending(a => a.İletişimID).ToListAsync();
            return View(iletişimlerim);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> İletişimSil(int id)
        {
            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            İletişim iletişim= await _context.İletişimler.FindAsync(id);
            _context.İletişimler.Remove(iletişim);
            await _context.SaveChangesAsync();
           
            IEnumerable<İletişim> iletişimlerim = await _context.İletişimler.Where(a => a.KullanıcıID == sidd).ToListAsync();
            return RedirectToAction("İletişim", "Profil");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> İletişimGüncelle([Bind("İletişimAdı,TelefonNo")] İletişim iletişim,int id)
        {
            
            int sidd = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            iletişim.KullanıcıID = sidd;
            iletişim.İletişimID= id;
            if (ModelState.IsValid)
            {
                _context.Update(iletişim);
                await _context.SaveChangesAsync();
                ViewBag.SuccessMessage = "İletişim bilgisi başarıyla eklendi";



                return RedirectToAction("İletişim","Profil");
            }
            
            return RedirectToAction("İletişim","Profil");

        }


    }
}
