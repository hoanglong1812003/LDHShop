using Microsoft.AspNetCore.Mvc;
using LDHShop.Data;
using LDHShop.ViewModels;

namespace LDHShop.ViewComponents
{
    public class MenuLoaiViewComponent : ViewComponent
    {
        private readonly LdhshopContext db;

        public MenuLoaiViewComponent(LdhshopContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.Loais.Select(loai => new MenuLoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
                SoLuong = loai.HangHoas.Count
            }).OrderBy(p => p.TenLoai);
            return View(data);
        }
    }
}
