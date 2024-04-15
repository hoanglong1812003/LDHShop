namespace LDHShop.Data
{
	public class HinhThucThanhToan
	{
		public int Id { get; set; }

		public string CachThanhToan { get; set; } = null!;

		public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
	}
}