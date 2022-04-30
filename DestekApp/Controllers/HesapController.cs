using DestekApp.Data;
using DestekApp.Helper;
using DestekApp.Models;
using DestekApp.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DestekApp.Controllers
{
    public class HesapController : Controller
    {

        //dependency  ınjection  bagımlılıkları ortadan kaldırma...
        private readonly DestekAppDBContext _context;

        public HesapController(DestekAppDBContext context)
        {
            _context = context;
        }
        public IActionResult Kayıt()
        {
            return View();
        }

        /*
         * mvc : 
         * data almaya get  vermeye post  
         * veritabında data  gönderiyorsa post  
         * data alıyorsa gettir.  en çok kullanılan metotdur.
         * herhangi bir şey belirtmiyorsak  default olarak  get olur. 
         * 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kayıt([Bind("KullanıcıID,Eposta,Şifre,ŞifreTekrarı,RolID")] Kullanıcı kullanıcı)
        {


            if (ModelState.IsValid)
            {
                if (_context.Kullanıcılar.Any(a => a.Eposta == kullanıcı.Eposta))
                {
                    ModelState.AddModelError("", "Bu kullanıcı alınmış..");
                    return View(kullanıcı);
                }
                if (kullanıcı.RolID!=1)
                {
                    ModelState.AddModelError("", "Şüpheli İşlem");
                    return View(kullanıcı);
                }
                _context.Add(kullanıcı);
                await _context.SaveChangesAsync();
                Epostaİşlemleri.AktivasyonMailiGonder(kullanıcı.Eposta);
                return Redirect("AktivasyonBilgisi");


            }
            return View(kullanıcı);
        }


        public IActionResult Giriş()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Giriş([Bind("Eposta,Şifre")]GirişViewModel x)
        {

            if (ModelState.IsValid)
            {
                ClaimsIdentity kimlik = null;
                bool kimlikDoğrulandıMı = false;
                Kullanıcı kullanıcı = await _context.Kullanıcılar.Include(k => k.Rol).FirstOrDefaultAsync(m => m.Eposta == x.Eposta && m.Şifre == x.Şifre);


                if (kullanıcı == null)
                {
                    ModelState.AddModelError("", "Eposta veya Şifre yanlış");
                    return View(x);
                }


                kimlik = new ClaimsIdentity
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,kullanıcı.KullanıcıID.ToString()),
                            new Claim(ClaimTypes.Email,kullanıcı.Eposta),
                            new Claim(ClaimTypes.Role,kullanıcı.Rol.RolAdı),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                );



                kimlikDoğrulandıMı = true;

                if (kimlikDoğrulandıMı)
                {
                    var ilkeler = new ClaimsPrincipal(kimlik);
                    var giriş = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, ilkeler);




                    if (kullanıcı.RolID == 1)
                    {
                        return Redirect("~/Hesap/AktivasyonBilgisi");
                    }
                    else if (kullanıcı.RolID == 2)
                    {
                        return Redirect("~/Anasayfa/Index");
                    }

                    else
                    {
                        return Redirect("~/Anasayfa/Index");
                    }



                }
            }
            
            return View(x);

        }


        public IActionResult ŞifremiUnuttum()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ŞifremiUnuttum(string Eposta)
        {

            Epostaİşlemleri.ŞifremiUnuttumMaili(Eposta);
            
            return  RedirectToAction("Giriş", "Hesap");

        }

        public IActionResult ŞifreSıfırla(string xrtt)
        {

            return View("ŞifreSıfırla",xrtt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ŞifreSıfırla([Bind("EpostaKapalıı,Şifre,ŞifreTekrarı")] ŞifremiUnuttumViewModel x)
        {
            if (ModelState.IsValid)
            {
                string epostaAçık = Şifreleme.SifreyiCoz(x.EpostaKapalıı);
                Kullanıcı kullanıcı= _context.Kullanıcılar.FirstOrDefault(a => a.Eposta == epostaAçık);

                if (kullanıcı==null)
                {
                    return NotFound();
                }

                kullanıcı.Şifre = x.Şifre;
                _context.Update(kullanıcı);
                _context.SaveChanges(); 
                return RedirectToAction("Giriş");

            }
            return RedirectToAction("ŞifreSıfırla", new { xrtt = x.EpostaKapalıı});
        }

        public IActionResult AktivasyonBilgisi()
        {
            return View();
        }
        public IActionResult EpostaAktivasyon(string kkk)
        {
            string eposta= Şifreleme.SifreyiCoz(kkk);
            Kullanıcı kullanıcı = _context.Kullanıcılar.FirstOrDefault(a => a.Eposta == eposta);
            if (kullanıcı!=null)
            {
                kullanıcı.RolID = 2;
                _context.Update(kullanıcı);
                _context.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Çıkış()
        {
            var giriş = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
