using System;
using System.Collections.Generic;

namespace LDHShop.Data;

public partial class HangHoa
{
	public string? MoTa { get; set; }

	public string MaNcc { get; set; } = null!;

	public int MaHh { get; set; }

	public string TenHh { get; set; } = null!;

	public int MaLoai { get; set; }

	public string? DonViTinh { get; set; }

	public decimal GiaNhap { get; set; }

	public decimal GiaBan { get; set; }

	public string? Hinh { get; set; }

	public decimal? GiamGia { get; set; }

	public int SoLuongTon { get; set; }

	public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

	public virtual Loai MaLoaiNavigation { get; set; } = null!;

	public virtual ICollection<NhapHang> NhapHangs { get; set; } = new List<NhapHang>();

	public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();
}
