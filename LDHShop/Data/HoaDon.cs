using System;
using System.Collections.Generic;

namespace LDHShop.Data;

public partial class HoaDon
{
	public int MaHd { get; set; }

	public string MaKh { get; set; } = null!;

	public DateTime NgayDat { get; set; }

	public DateTime? NgayGiao { get; set; }

	public string HoTen { get; set; } = null!;

	public string Sdt { get; set; } = null!;

	public string DiaChi { get; set; } = null!;

	public int CachThanhToan { get; set; }

	public int CachVanChuyen { get; set; }

	public decimal? PhiVanChuyen { get; set; }

	public int MaTrangThai { get; set; }

	public decimal? TongTien { get; set; }

	public string MaNv { get; set; } = null!;

	public virtual HinhThucThanhToan CachThanhToanNavigation { get; set; } = null!;

	public virtual HinhThucVanChuyen CachVanChuyenNavigation { get; set; } = null!;

	public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

	public virtual KhachHang MaKhNavigation { get; set; } = null!;

	public virtual NhanVien MaNvNavigation { get; set; } = null!;

	public virtual TrangThai MaTrangThaiNavigation { get; set; } = null!;
}
