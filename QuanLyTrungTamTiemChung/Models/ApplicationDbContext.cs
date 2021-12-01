using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace QuanLyTrungTamTiemChung.Models
{


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<BACSI> BACSI { get; set; }
        public virtual DbSet<COSO> COSO { get; set; }
        public virtual DbSet<CT_GOIVX> CT_GOIVX { get; set; }
        public virtual DbSet<CT_PHIEUTIEM> CT_PHIEUTIEM { get; set; }
        public virtual DbSet<CT_PHIEUXUAT> CT_PHIEUXUAT { get; set; }
        public virtual DbSet<GOIVACXIN> GOIVACXIN { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<KHO> KHO { get; set; }
        public virtual DbSet<LOAIVACXIN> LOAIVACXIN { get; set; }
        public virtual DbSet<LOVACXIN> LOVACXIN { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<NHASANXUAT> NHASANXUAT { get; set; }
        public virtual DbSet<PHANQUYEN> PHANQUYEN { get; set; }
        public virtual DbSet<PHIEUDANGKY> PHIEUDANGKY { get; set; }
        public virtual DbSet<PHIEUKHAM> PHIEUKHAM { get; set; }
        public virtual DbSet<PHIEUNHAP> PHIEUNHAP { get; set; }
        public virtual DbSet<PHIEUTIEM> PHIEUTIEM { get; set; }
        public virtual DbSet<PHIEUXUAT> PHIEUXUAT { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<VACXIN> VACXIN { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BACSI>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<BACSI>()
                .Property(e => e.LUONG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<COSO>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<CT_GOIVX>()
                .Property(e => e.LIEULUONG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_GOIVX>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_GOIVX>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_PHIEUTIEM>()
                .Property(e => e.LIEULUONG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_PHIEUTIEM>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_PHIEUTIEM>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_PHIEUXUAT>()
                .Property(e => e.DONGIAXUAT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_PHIEUXUAT>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GOIVACXIN>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<GOIVACXIN>()
                .HasMany(e => e.CT_GOIVX)
                .WithRequired(e => e.GOIVACXIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDTTHANNHAN)
                .IsUnicode(false);

            modelBuilder.Entity<KHO>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHO>()
                .HasMany(e => e.PHIEUXUAT)
                .WithOptional(e => e.KHO)
                .HasForeignKey(e => e.MAKHODICH);

            modelBuilder.Entity<KHO>()
                .HasMany(e => e.PHIEUXUAT1)
                .WithOptional(e => e.KHO1)
                .HasForeignKey(e => e.MAKHONGUON);

            modelBuilder.Entity<LOVACXIN>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LOVACXIN>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.LUONG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<NHASANXUAT>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAP>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUTIEM>()
                .HasMany(e => e.CT_PHIEUTIEM)
                .WithRequired(e => e.PHIEUTIEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUXUAT>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PHIEUXUAT>()
                .HasMany(e => e.CT_PHIEUXUAT)
                .WithRequired(e => e.PHIEUXUAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VACXIN>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VACXIN>()
                .HasMany(e => e.CT_GOIVX)
                .WithRequired(e => e.VACXIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VACXIN>()
                .HasMany(e => e.CT_PHIEUTIEM)
                .WithRequired(e => e.VACXIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VACXIN>()
                .HasMany(e => e.CT_PHIEUXUAT)
                .WithRequired(e => e.VACXIN)
                .WillCascadeOnDelete(false);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}