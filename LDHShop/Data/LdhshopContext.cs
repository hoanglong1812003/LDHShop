using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LDHShop.Data;

public partial class LdhshopContext : DbContext
{
	public LdhshopContext()
	{
	}

	public LdhshopContext(DbContextOptions<LdhshopContext> options)
		: base(options)
	{
	}

	public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

	public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

	public virtual DbSet<ChucVu> ChucVus { get; set; }

	public virtual DbSet<GioHang> GioHangs { get; set; }

	public virtual DbSet<HangHoa> HangHoas { get; set; }

	public virtual DbSet<HinhThucThanhToan> HinhThucThanhToans { get; set; }

	public virtual DbSet<HinhThucVanChuyen> HinhThucVanChuyens { get; set; }

	public virtual DbSet<HoaDon> HoaDons { get; set; }

	public virtual DbSet<KhachHang> KhachHangs { get; set; }

	public virtual DbSet<Loai> Loais { get; set; }

	public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

	public virtual DbSet<NhanVien> NhanViens { get; set; }

	public virtual DbSet<NhapHang> NhapHangs { get; set; }

	public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; }

	public virtual DbSet<TrangThai> TrangThais { get; set; }

	public virtual DbSet<VChiTietHoaDon> VChiTietHoaDons { get; set; }

	public virtual DbSet<YeuThich> YeuThiches { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ChiTietGioHang>(entity =>
		{
			entity.HasKey(e => new { e.MaGioHang, e.MaHh }).HasName("PK__ChiTietG__A77247CD58B21525");

			entity.ToTable("ChiTietGioHang", tb => tb.HasTrigger("UpdateCTGH"));

			entity.Property(e => e.MaHh).HasColumnName("MaHH");
			entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.GiamGia)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(10, 2)");
			entity.Property(e => e.SoLuong).HasDefaultValue(1);
			entity.Property(e => e.SoTien)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(10, 2)");

			entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.ChiTietGioHangs)
				.HasForeignKey(d => d.MaGioHang)
				.HasConstraintName("FK_ChiTietGioHang_GioHang");
		});

		modelBuilder.Entity<ChiTietHd>(entity =>
		{
			entity.HasKey(e => e.MaCt).HasName("PK_OrderDetails");

			entity.ToTable("ChiTietHD", tb => tb.HasTrigger("UpdateTienHD"));

			entity.Property(e => e.MaCt).HasColumnName("MaCT");
			entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.GiamGia).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.MaHd).HasColumnName("MaHD");
			entity.Property(e => e.MaHh).HasColumnName("MaHH");
			entity.Property(e => e.SoLuong).HasDefaultValue(1);

			entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
				.HasForeignKey(d => d.MaHd)
				.HasConstraintName("FK_ChiTietHD_HoaDon");

			entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.ChiTietHds)
				.HasForeignKey(d => d.MaHh)
				.HasConstraintName("FK_ChiTietHD_HangHoa");
		});

		modelBuilder.Entity<ChucVu>(entity =>
		{
			entity.HasKey(e => e.MaCV);

			entity.ToTable("ChucVu");

			entity.Property(e => e.MaCV)
				.HasMaxLength(7)
				.IsUnicode(false)
				.HasColumnName("MaCV");
			entity.Property(e => e.TenCV).HasMaxLength(50);
		});

		modelBuilder.Entity<GioHang>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__GioHang__3214EC27839FDF4D");

			entity.ToTable("GioHang");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.MaKh)
				.HasMaxLength(20)
				.HasColumnName("MaKH");
			entity.Property(e => e.TongThanhToan).HasColumnType("decimal(10, 2)");

			entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.GioHangs)
				.HasForeignKey(d => d.MaKh)
				.HasConstraintName("FK_GioHang_KhachHang");
		});

		modelBuilder.Entity<HangHoa>(entity =>
		{
			entity.HasKey(e => e.MaHh);

			entity.ToTable("HangHoa");

			entity.Property(e => e.MaHh)
				.ValueGeneratedNever()
				.HasColumnName("MaHH");
			entity.Property(e => e.DonViTinh).HasMaxLength(50);
			entity.Property(e => e.GiaBan).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.GiaNhap).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.GiamGia)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(10, 2)");
			entity.Property(e => e.Hinh).HasMaxLength(50);
			entity.Property(e => e.MaNcc)
				.HasMaxLength(50)
				.HasColumnName("MaNCC");
			entity.Property(e => e.TenHh)
				.HasMaxLength(50)
				.HasColumnName("TenHH");

			entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.HangHoas)
				.HasForeignKey(d => d.MaLoai)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_HangHoa_Loai");
		});

		modelBuilder.Entity<HinhThucThanhToan>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__HinhThuc__3214EC272B5670BA");

			entity.ToTable("HinhThucThanhToan");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.CachThanhToan).HasMaxLength(50);
		});

		modelBuilder.Entity<HinhThucVanChuyen>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__HinhThuc__3214EC27687581BE");

			entity.ToTable("HinhThucVanChuyen");

			entity.Property(e => e.Id).HasColumnName("ID");
			entity.Property(e => e.HinhThucVanChuyen1)
				.HasMaxLength(50)
				.HasColumnName("HinhThucVanChuyen");
		});

		modelBuilder.Entity<HoaDon>(entity =>
		{
			entity.HasKey(e => e.MaHd);

			entity.ToTable("HoaDon");

			entity.Property(e => e.MaHd).HasColumnName("MaHD");
			entity.Property(e => e.HoTen).HasMaxLength(50);
			entity.Property(e => e.MaKh)
				.HasMaxLength(20)
				.HasColumnName("MaKH");
			entity.Property(e => e.MaNv)
				.HasMaxLength(7)
				.IsUnicode(false)
				.HasColumnName("MaNV");
			entity.Property(e => e.NgayDat).HasColumnType("datetime");
			entity.Property(e => e.NgayGiao).HasColumnType("datetime");
			entity.Property(e => e.PhiVanChuyen).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.Sdt)
				.HasMaxLength(24)
				.HasColumnName("SDT");
			entity.Property(e => e.TongTien)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(18, 2)");

			entity.HasOne(d => d.CachThanhToanNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.CachThanhToan)
				.HasConstraintName("FK_HoaDon_HinhThucThanhToan");

			entity.HasOne(d => d.CachVanChuyenNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.CachVanChuyen)
				.HasConstraintName("FK_HoaDon_HinhThucVanChuyen");

			entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.MaKh)
				.HasConstraintName("FK_HoaDon_KhachHang");

			entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.MaNv)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("FK_HoaDon_NhanVien");

			entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.HoaDons)
				.HasForeignKey(d => d.MaTrangThai)
				.HasConstraintName("FK_HoaDon_TrangThai");
		});

		modelBuilder.Entity<KhachHang>(entity =>
		{
			entity.HasKey(e => e.MaKh).HasName("PK_Customers");

			entity.ToTable("KhachHang");

			entity.Property(e => e.MaKh)
				.HasMaxLength(20)
				.HasColumnName("MaKH");
			entity.Property(e => e.DiaChi).HasMaxLength(60);
			entity.Property(e => e.DienThoai).HasMaxLength(24);
			entity.Property(e => e.Email).HasMaxLength(50);
			entity.Property(e => e.Hinh)
				.HasMaxLength(50)
				.HasDefaultValue("Photo.gif");
			entity.Property(e => e.HoTen).HasMaxLength(50);
			entity.Property(e => e.MatKhau).HasMaxLength(50);
			entity.Property(e => e.NgaySinh)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
		});

		modelBuilder.Entity<Loai>(entity =>
		{
			entity.HasKey(e => e.MaLoai).HasName("PK_Categories");

			entity.ToTable("Loai");

			entity.Property(e => e.Hinh).HasMaxLength(50);
			entity.Property(e => e.TenLoai).HasMaxLength(50);
		});

		modelBuilder.Entity<NhaCungCap>(entity =>
		{
			entity.HasKey(e => e.MaNcc).HasName("PK_Suppliers");

			entity.ToTable("NhaCungCap");

			entity.Property(e => e.MaNcc)
				.HasMaxLength(50)
				.HasColumnName("MaNCC");
			entity.Property(e => e.DiaChi).HasMaxLength(50);
			entity.Property(e => e.DienThoai).HasMaxLength(50);
			entity.Property(e => e.Email).HasMaxLength(50);
			entity.Property(e => e.Logo).HasMaxLength(50);
			entity.Property(e => e.NguoiLienLac).HasMaxLength(50);
			entity.Property(e => e.TenCongTy).HasMaxLength(50);
		});

		modelBuilder.Entity<NhanVien>(entity =>
		{
			entity.HasKey(e => e.MaNv).HasName("PK_NhanVien_1");

			entity.ToTable("NhanVien");

			entity.Property(e => e.MaNv)
				.HasMaxLength(7)
				.IsUnicode(false)
				.HasColumnName("MaNV");
			entity.Property(e => e.Email)
				.HasMaxLength(50)
				.IsUnicode(false);
			entity.Property(e => e.HoTen).HasMaxLength(50);
			entity.Property(e => e.MaCV)
				.HasMaxLength(7)
				.IsUnicode(false)
				.HasColumnName("MaCV");
			entity.Property(e => e.MatKhau).HasMaxLength(100);

			entity.HasOne(d => d.ChucVuNavigation).WithMany(p => p.NhanViens)
				.HasForeignKey(d => d.MaCV)
				.HasConstraintName("FK_NhanVien_ChucVu");
		});

		modelBuilder.Entity<NhapHang>(entity =>
		{
			entity.HasKey(e => new { e.MaPhieu, e.MaHh });

			entity.ToTable("NhapHang", tb =>
			{
				tb.HasTrigger("UpdateTienNhapHang");
				tb.HasTrigger("updateSLT");
			});

			entity.Property(e => e.MaHh).HasColumnName("MaHH");
			entity.Property(e => e.GiaNhap).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.GiamGia).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.ThanhTien)
				.HasDefaultValue(0m)
				.HasColumnType("decimal(10, 2)");

			entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.NhapHangs)
				.HasForeignKey(d => d.MaHh)
				.HasConstraintName("FK_NhapHang_HangHoa");

			entity.HasOne(d => d.MaPhieuNavigation).WithMany(p => p.NhapHangs)
				.HasForeignKey(d => d.MaPhieu)
				.HasConstraintName("FK_NhapHang_PhieuNhapHang");
		});

		modelBuilder.Entity<PhieuNhapHang>(entity =>
		{
			entity.HasKey(e => e.MaPhieu);

			entity.ToTable("PhieuNhapHang");

			entity.Property(e => e.MaPhieu).ValueGeneratedNever();
			entity.Property(e => e.MaNcc)
				.HasMaxLength(50)
				.HasColumnName("MaNCC");
			entity.Property(e => e.NgayNhap)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

			entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhapHangs)
				.HasForeignKey(d => d.MaNcc)
				.HasConstraintName("FK_PhieuNhapHang_NhaCungCap");
		});

		modelBuilder.Entity<TrangThai>(entity =>
		{
			entity.HasKey(e => e.MaTrangThai);

			entity.ToTable("TrangThai");

			entity.Property(e => e.MaTrangThai).ValueGeneratedNever();
			entity.Property(e => e.MoTa).HasMaxLength(500);
			entity.Property(e => e.TenTrangThai).HasMaxLength(50);
		});

		modelBuilder.Entity<VChiTietHoaDon>(entity =>
		{
			entity
				.HasNoKey()
				.ToView("vChiTietHoaDon");

			entity.Property(e => e.DonGia).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.GiamGia).HasColumnType("decimal(10, 2)");
			entity.Property(e => e.MaCt).HasColumnName("MaCT");
			entity.Property(e => e.MaHd).HasColumnName("MaHD");
			entity.Property(e => e.MaHh).HasColumnName("MaHH");
			entity.Property(e => e.TenHh)
				.HasMaxLength(50)
				.HasColumnName("TenHH");
		});

		modelBuilder.Entity<YeuThich>(entity =>
		{
			entity.HasKey(e => e.MaYt).HasName("PK_Favorites");

			entity.ToTable("YeuThich");

			entity.Property(e => e.MaYt).HasColumnName("MaYT");
			entity.Property(e => e.MaHh).HasColumnName("MaHH");
			entity.Property(e => e.MaKh)
				.HasMaxLength(20)
				.HasColumnName("MaKH");
			entity.Property(e => e.MoTa).HasMaxLength(255);

			entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.YeuThiches)
				.HasForeignKey(d => d.MaHh)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_YeuThich_HangHoa");

			entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.YeuThiches)
				.HasForeignKey(d => d.MaKh)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_YeuThich_KhachHang");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
