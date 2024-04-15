using System;
using System.Collections.Generic;

namespace LDHShop.Data;

public partial class ChucVu
{
    public string MaCV { get; set; } = null!;

    public string TenCV { get; set; } = null!;

    public string? ThongTin { get; set; }
	public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();


}
