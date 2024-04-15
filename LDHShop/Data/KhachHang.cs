﻿using System;
using System.Collections.Generic;

namespace LDHShop.Data;

public partial class KhachHang
{
	public string MaKh { get; set; } = null!;

	public string? MatKhau { get; set; }

	public string HoTen { get; set; } = null!;

	public bool GioiTinh { get; set; }

	public DateTime NgaySinh { get; set; }

	public string? DiaChi { get; set; }

	public string? DienThoai { get; set; }

	public string Email { get; set; } = null!;

	public string? Hinh { get; set; }

	public bool HieuLuc { get; set; }

	public int VaiTro { get; set; }

	public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

	public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

	public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();

	public string? RandomKey { get; set; }
}
