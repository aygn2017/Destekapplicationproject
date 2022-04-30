using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DestekApp.Controllers
{
    [Authorize(Roles="UserNormal")]
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
