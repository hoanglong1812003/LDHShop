using LDHShop.Data;
using LDHShop.ViewModels;
using LDHShop.Data;
using LDHShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LDHShop.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly LdhshopContext db;

        public HangHoaController(LdhshopContext conetxt)
        {
            db = conetxt;
        }

        public IActionResult Index(int? loai)
        {
            var hangHoas = db.HangHoas.AsQueryable();

            if (loai.HasValue)
            {
                hangHoas = hangHoas.Where(p => p.MaLoai == loai.Value);
            }

            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHh,
                TenHH = p.TenHh,
                DonGia = (double) p.GiaBan,
                Hinh = p.Hinh ?? "",
                MoTa = p.DonViTinh ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }

        public IActionResult Search(string? query)
        {
            var hangHoas = db.HangHoas.AsQueryable();

            if (query != null)
            {
                hangHoas = hangHoas.Where(p => p.TenHh.Contains(query));
            }

            var result = hangHoas.Select(p => new HangHoaVM
            {
                MaHH = p.MaHh,
                TenHH = p.TenHh,
                DonGia = (double) p.GiaBan,
                Hinh = p.Hinh ?? "",
                MoTa = p.DonViTinh ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }


        public IActionResult Detail(int id)
        {
            var data = db.HangHoas
                .SingleOrDefault(p => p.MaHh == id);
            if (data == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }

            var result = new ChiTietHangHoaVM
            {
                MaHH = data.MaHh,
                TenHH = data.TenHh,
                DonGia = (double)data.GiaBan,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                MoTa = data.DonViTinh ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,//tính sau
                DiemDanhGia = 5,//check sau
            };
            return View(result);
        }
    }
}