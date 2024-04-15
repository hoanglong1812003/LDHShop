namespace LDHShop.Data
{
	public class ChiTietGioHang
	{
		public int MaGioHang { get; set; }

		public int MaHh { get; set; }

		public decimal DonGia { get; set; }

		public int SoLuong { get; set; }

		public decimal? SoTien { get; set; }

		public decimal? GiamGia { get; set; }

		public virtual GioHang MaGioHangNavigation { get; set; } = null!;
	}
}