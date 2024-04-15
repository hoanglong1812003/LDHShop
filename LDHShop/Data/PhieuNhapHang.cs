namespace LDHShop.Data
{
	public class PhieuNhapHang
	{
		public decimal? TongTien { get; set; }

		public int MaPhieu { get; set; }

		public string MaNcc { get; set; } = null!;

		public DateTime NgayNhap { get; set; }

		public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

		public virtual ICollection<NhapHang> NhapHangs { get; set; } = new List<NhapHang>();
	}
}