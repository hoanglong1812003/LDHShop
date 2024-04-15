namespace LDHShop.Data
{
	public class GioHang
	{
		public int Id { get; set; }

		public string MaKh { get; set; } = null!;

		public decimal TongThanhToan { get; set; }

		public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

		public virtual KhachHang MaKhNavigation { get; set; } = null!;
	}
}