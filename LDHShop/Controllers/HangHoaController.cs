using Microsoft.AspNetCore.Mvc;

namespace LDHShop.Controllers
{
    public class HangHoaController : Controller
    {
        public IActionResult Index(int? loai)
        {
            return View();
        }
    }
}
