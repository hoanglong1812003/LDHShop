namespace LDHShop.Data
{
	public class NhapHang
	{
		public int MaPhieu { get; set; }

		public int MaHh { get; set; }

		public int SoLuong { get; set; }

		public decimal GiaNhap { get; set; }

		public decimal? GiamGia { get; set; }

		public decimal? ThanhTien { get; set; }

		public virtual HangHoa MaHhNavigation { get; set; } = null!;

		public virtual PhieuNhapHang MaPhieuNavigation { get; set; } = null!;
	}
}