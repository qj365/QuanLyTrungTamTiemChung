namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BACSI",
                c => new
                    {
                        MABS = c.Int(nullable: false),
                        TENBS = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 15, unicode: false),
                        DIACHI = c.String(maxLength: 50),
                        GIOITINH = c.String(maxLength: 10),
                        NGAYSINH = c.DateTime(storeType: "date"),
                        HOCVI = c.String(maxLength: 50),
                        LUONG = c.Decimal(precision: 18, scale: 0),
                        IDTAIKHOAN = c.Int(),
                        MACS = c.Int(),
                    })
                .PrimaryKey(t => t.MABS)
                .ForeignKey("dbo.COSO", t => t.MACS)
                .ForeignKey("dbo.TAIKHOAN", t => t.IDTAIKHOAN)
                .Index(t => t.IDTAIKHOAN)
                .Index(t => t.MACS);
            
            CreateTable(
                "dbo.COSO",
                c => new
                    {
                        MACS = c.Int(nullable: false),
                        TENCS = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 15, unicode: false),
                        DIACHI = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MACS);
            
            CreateTable(
                "dbo.KHO",
                c => new
                    {
                        MAKHO = c.Int(nullable: false),
                        TENKHO = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 15, unicode: false),
                        DIACHI = c.String(maxLength: 50),
                        MACS = c.Int(),
                    })
                .PrimaryKey(t => t.MAKHO)
                .ForeignKey("dbo.COSO", t => t.MACS)
                .Index(t => t.MACS);
            
            CreateTable(
                "dbo.LOAIVACXIN",
                c => new
                    {
                        MALOAI = c.Int(nullable: false),
                        TENLOAI = c.String(maxLength: 50),
                        MAKHO = c.Int(),
                    })
                .PrimaryKey(t => t.MALOAI)
                .ForeignKey("dbo.KHO", t => t.MAKHO)
                .Index(t => t.MAKHO);
            
            CreateTable(
                "dbo.VACXIN",
                c => new
                    {
                        MAVX = c.Int(nullable: false),
                        TENVX = c.String(maxLength: 50),
                        NSX = c.DateTime(storeType: "date"),
                        HSD = c.DateTime(storeType: "date"),
                        SOLUONG = c.Int(),
                        DONGIA = c.Decimal(precision: 18, scale: 0),
                        MALO = c.Int(),
                        MALOAI = c.Int(),
                    })
                .PrimaryKey(t => t.MAVX)
                .ForeignKey("dbo.LOVACXIN", t => t.MALO)
                .ForeignKey("dbo.LOAIVACXIN", t => t.MALOAI)
                .Index(t => t.MALO)
                .Index(t => t.MALOAI);
            
            CreateTable(
                "dbo.CT_GOIVX",
                c => new
                    {
                        MAGOIVX = c.Int(nullable: false),
                        MAVX = c.Int(nullable: false),
                        LIEULUONG = c.Decimal(precision: 18, scale: 0),
                        SOLUONG = c.Int(),
                        DONGIA = c.Decimal(precision: 18, scale: 0),
                        THANHTIEN = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.MAGOIVX, t.MAVX })
                .ForeignKey("dbo.GOIVACXIN", t => t.MAGOIVX)
                .ForeignKey("dbo.VACXIN", t => t.MAVX)
                .Index(t => t.MAGOIVX)
                .Index(t => t.MAVX);
            
            CreateTable(
                "dbo.GOIVACXIN",
                c => new
                    {
                        MAGOIVX = c.Int(nullable: false),
                        TENGOIVX = c.String(maxLength: 50),
                        MOTA = c.String(maxLength: 50),
                        TONGTIEN = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.MAGOIVX);
            
            CreateTable(
                "dbo.PHIEUTIEM",
                c => new
                    {
                        MAPHIEUTIEM = c.Int(nullable: false),
                        NGAYTIEM = c.DateTime(storeType: "date"),
                        MAPHIEUKHAM = c.Int(),
                        MABS = c.Int(),
                        MAGOIVX = c.Int(),
                    })
                .PrimaryKey(t => t.MAPHIEUTIEM)
                .ForeignKey("dbo.BACSI", t => t.MABS)
                .ForeignKey("dbo.GOIVACXIN", t => t.MAGOIVX)
                .ForeignKey("dbo.PHIEUKHAM", t => t.MAPHIEUKHAM)
                .Index(t => t.MAPHIEUKHAM)
                .Index(t => t.MABS)
                .Index(t => t.MAGOIVX);
            
            CreateTable(
                "dbo.CT_PHIEUTIEM",
                c => new
                    {
                        MAPHIEUTIEM = c.Int(nullable: false),
                        MAVX = c.Int(nullable: false),
                        LIEULUONG = c.Decimal(precision: 18, scale: 0),
                        SOLUONG = c.Int(),
                        DONGIA = c.Decimal(precision: 18, scale: 0),
                        THANHTIEN = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.MAPHIEUTIEM, t.MAVX })
                .ForeignKey("dbo.PHIEUTIEM", t => t.MAPHIEUTIEM)
                .ForeignKey("dbo.VACXIN", t => t.MAVX)
                .Index(t => t.MAPHIEUTIEM)
                .Index(t => t.MAVX);
            
            CreateTable(
                "dbo.HOADON",
                c => new
                    {
                        MAHD = c.Int(nullable: false),
                        NGAYLAP = c.DateTime(storeType: "date"),
                        TONGTIEN = c.Decimal(precision: 18, scale: 0),
                        MANV = c.Int(),
                        MAPHIEUTIEM = c.Int(),
                    })
                .PrimaryKey(t => t.MAHD)
                .ForeignKey("dbo.NHANVIEN", t => t.MANV)
                .ForeignKey("dbo.PHIEUTIEM", t => t.MAPHIEUTIEM)
                .Index(t => t.MANV)
                .Index(t => t.MAPHIEUTIEM);
            
            CreateTable(
                "dbo.NHANVIEN",
                c => new
                    {
                        MANV = c.Int(nullable: false),
                        TENNV = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 15, unicode: false),
                        CHUCVU = c.String(maxLength: 50),
                        LUONG = c.Decimal(precision: 18, scale: 0),
                        GIOITINH = c.String(maxLength: 10),
                        NGAYSINH = c.DateTime(storeType: "date"),
                        MACS = c.Int(),
                        IDTAIKHOAN = c.Int(),
                    })
                .PrimaryKey(t => t.MANV)
                .ForeignKey("dbo.COSO", t => t.MACS)
                .ForeignKey("dbo.TAIKHOAN", t => t.IDTAIKHOAN)
                .Index(t => t.MACS)
                .Index(t => t.IDTAIKHOAN);
            
            CreateTable(
                "dbo.PHIEUNHAP",
                c => new
                    {
                        MAPN = c.Int(nullable: false),
                        NGAYNHAP = c.DateTime(storeType: "date"),
                        TONGTIEN = c.Decimal(precision: 18, scale: 0),
                        MANSX = c.Int(),
                        MANV = c.Int(),
                    })
                .PrimaryKey(t => t.MAPN)
                .ForeignKey("dbo.NHANVIEN", t => t.MANV)
                .ForeignKey("dbo.NHASANXUAT", t => t.MANSX)
                .Index(t => t.MANSX)
                .Index(t => t.MANV);
            
            CreateTable(
                "dbo.LOVACXIN",
                c => new
                    {
                        MALO = c.Int(nullable: false),
                        SOLUONG = c.Int(),
                        DONGIA = c.Decimal(precision: 18, scale: 0),
                        THANHTIEN = c.Decimal(precision: 18, scale: 0),
                        MAPN = c.Int(),
                    })
                .PrimaryKey(t => t.MALO)
                .ForeignKey("dbo.PHIEUNHAP", t => t.MAPN)
                .Index(t => t.MAPN);
            
            CreateTable(
                "dbo.NHASANXUAT",
                c => new
                    {
                        MANSX = c.Int(nullable: false),
                        TENNSX = c.String(maxLength: 50),
                        DIACHI = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MANSX);
            
            CreateTable(
                "dbo.PHIEUXUAT",
                c => new
                    {
                        MAPHIEUXUAT = c.Int(nullable: false),
                        NGAYLAP = c.DateTime(storeType: "date"),
                        TONGTIEN = c.Decimal(precision: 18, scale: 0),
                        MAKHODICH = c.Int(),
                        MAKHONGUON = c.Int(),
                        MANV = c.Int(),
                    })
                .PrimaryKey(t => t.MAPHIEUXUAT)
                .ForeignKey("dbo.NHANVIEN", t => t.MANV)
                .ForeignKey("dbo.KHO", t => t.MAKHODICH)
                .ForeignKey("dbo.KHO", t => t.MAKHONGUON)
                .Index(t => t.MAKHODICH)
                .Index(t => t.MAKHONGUON)
                .Index(t => t.MANV);
            
            CreateTable(
                "dbo.CT_PHIEUXUAT",
                c => new
                    {
                        MAPHIEUXUAT = c.Int(nullable: false),
                        MAVX = c.Int(nullable: false),
                        SOLUONG = c.Int(),
                        DONGIAXUAT = c.Decimal(precision: 18, scale: 0),
                        THANHTIEN = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => new { t.MAPHIEUXUAT, t.MAVX })
                .ForeignKey("dbo.PHIEUXUAT", t => t.MAPHIEUXUAT)
                .ForeignKey("dbo.VACXIN", t => t.MAVX)
                .Index(t => t.MAPHIEUXUAT)
                .Index(t => t.MAVX);
            
            CreateTable(
                "dbo.TAIKHOAN",
                c => new
                    {
                        IDTAIKHOAN = c.Int(nullable: false),
                        TENDANGNHAP = c.String(maxLength: 50),
                        MATKHAU = c.String(maxLength: 50),
                        MAQUYEN = c.Int(),
                    })
                .PrimaryKey(t => t.IDTAIKHOAN)
                .ForeignKey("dbo.PHANQUYEN", t => t.MAQUYEN)
                .Index(t => t.MAQUYEN);
            
            CreateTable(
                "dbo.PHANQUYEN",
                c => new
                    {
                        MAQUYEN = c.Int(nullable: false),
                        TENQUYEN = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MAQUYEN);
            
            CreateTable(
                "dbo.PHIEUKHAM",
                c => new
                    {
                        MAPHIEUKHAM = c.Int(nullable: false),
                        NGAYKHAM = c.DateTime(storeType: "date"),
                        DIUNG = c.String(maxLength: 50),
                        NHIETDO = c.String(maxLength: 50),
                        HUYETAP = c.String(maxLength: 50),
                        MAPHIEUDK = c.Int(),
                        MABS = c.Int(),
                    })
                .PrimaryKey(t => t.MAPHIEUKHAM)
                .ForeignKey("dbo.BACSI", t => t.MABS)
                .ForeignKey("dbo.PHIEUDANGKY", t => t.MAPHIEUDK)
                .Index(t => t.MAPHIEUDK)
                .Index(t => t.MABS);
            
            CreateTable(
                "dbo.PHIEUDANGKY",
                c => new
                    {
                        MAPHIEUDK = c.Int(nullable: false),
                        NGAYLAPPHIEU = c.DateTime(storeType: "date"),
                        NGAYDANGKYTIEM = c.DateTime(storeType: "date"),
                        MACS = c.Int(),
                        MAKH = c.Int(),
                    })
                .PrimaryKey(t => t.MAPHIEUDK)
                .ForeignKey("dbo.COSO", t => t.MACS)
                .ForeignKey("dbo.KHACHHANG", t => t.MAKH)
                .Index(t => t.MACS)
                .Index(t => t.MAKH);
            
            CreateTable(
                "dbo.KHACHHANG",
                c => new
                    {
                        MAKH = c.Int(nullable: false),
                        TENKH = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 15, unicode: false),
                        DIACHI = c.String(maxLength: 50),
                        GIOITINH = c.String(maxLength: 10),
                        NGAYSINH = c.DateTime(storeType: "date"),
                        TENTHANNHAN = c.String(maxLength: 50),
                        MOIQUANHE = c.String(maxLength: 50),
                        SDTTHANNHAN = c.String(maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MAKH);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PHIEUXUAT", "MAKHONGUON", "dbo.KHO");
            DropForeignKey("dbo.PHIEUXUAT", "MAKHODICH", "dbo.KHO");
            DropForeignKey("dbo.VACXIN", "MALOAI", "dbo.LOAIVACXIN");
            DropForeignKey("dbo.CT_PHIEUXUAT", "MAVX", "dbo.VACXIN");
            DropForeignKey("dbo.CT_PHIEUTIEM", "MAVX", "dbo.VACXIN");
            DropForeignKey("dbo.CT_GOIVX", "MAVX", "dbo.VACXIN");
            DropForeignKey("dbo.PHIEUTIEM", "MAPHIEUKHAM", "dbo.PHIEUKHAM");
            DropForeignKey("dbo.PHIEUKHAM", "MAPHIEUDK", "dbo.PHIEUDANGKY");
            DropForeignKey("dbo.PHIEUDANGKY", "MAKH", "dbo.KHACHHANG");
            DropForeignKey("dbo.PHIEUDANGKY", "MACS", "dbo.COSO");
            DropForeignKey("dbo.PHIEUKHAM", "MABS", "dbo.BACSI");
            DropForeignKey("dbo.HOADON", "MAPHIEUTIEM", "dbo.PHIEUTIEM");
            DropForeignKey("dbo.TAIKHOAN", "MAQUYEN", "dbo.PHANQUYEN");
            DropForeignKey("dbo.NHANVIEN", "IDTAIKHOAN", "dbo.TAIKHOAN");
            DropForeignKey("dbo.BACSI", "IDTAIKHOAN", "dbo.TAIKHOAN");
            DropForeignKey("dbo.PHIEUXUAT", "MANV", "dbo.NHANVIEN");
            DropForeignKey("dbo.CT_PHIEUXUAT", "MAPHIEUXUAT", "dbo.PHIEUXUAT");
            DropForeignKey("dbo.PHIEUNHAP", "MANSX", "dbo.NHASANXUAT");
            DropForeignKey("dbo.PHIEUNHAP", "MANV", "dbo.NHANVIEN");
            DropForeignKey("dbo.VACXIN", "MALO", "dbo.LOVACXIN");
            DropForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP");
            DropForeignKey("dbo.HOADON", "MANV", "dbo.NHANVIEN");
            DropForeignKey("dbo.NHANVIEN", "MACS", "dbo.COSO");
            DropForeignKey("dbo.PHIEUTIEM", "MAGOIVX", "dbo.GOIVACXIN");
            DropForeignKey("dbo.CT_PHIEUTIEM", "MAPHIEUTIEM", "dbo.PHIEUTIEM");
            DropForeignKey("dbo.PHIEUTIEM", "MABS", "dbo.BACSI");
            DropForeignKey("dbo.CT_GOIVX", "MAGOIVX", "dbo.GOIVACXIN");
            DropForeignKey("dbo.LOAIVACXIN", "MAKHO", "dbo.KHO");
            DropForeignKey("dbo.KHO", "MACS", "dbo.COSO");
            DropForeignKey("dbo.BACSI", "MACS", "dbo.COSO");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PHIEUDANGKY", new[] { "MAKH" });
            DropIndex("dbo.PHIEUDANGKY", new[] { "MACS" });
            DropIndex("dbo.PHIEUKHAM", new[] { "MABS" });
            DropIndex("dbo.PHIEUKHAM", new[] { "MAPHIEUDK" });
            DropIndex("dbo.TAIKHOAN", new[] { "MAQUYEN" });
            DropIndex("dbo.CT_PHIEUXUAT", new[] { "MAVX" });
            DropIndex("dbo.CT_PHIEUXUAT", new[] { "MAPHIEUXUAT" });
            DropIndex("dbo.PHIEUXUAT", new[] { "MANV" });
            DropIndex("dbo.PHIEUXUAT", new[] { "MAKHONGUON" });
            DropIndex("dbo.PHIEUXUAT", new[] { "MAKHODICH" });
            DropIndex("dbo.LOVACXIN", new[] { "MAPN" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANV" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANSX" });
            DropIndex("dbo.NHANVIEN", new[] { "IDTAIKHOAN" });
            DropIndex("dbo.NHANVIEN", new[] { "MACS" });
            DropIndex("dbo.HOADON", new[] { "MAPHIEUTIEM" });
            DropIndex("dbo.HOADON", new[] { "MANV" });
            DropIndex("dbo.CT_PHIEUTIEM", new[] { "MAVX" });
            DropIndex("dbo.CT_PHIEUTIEM", new[] { "MAPHIEUTIEM" });
            DropIndex("dbo.PHIEUTIEM", new[] { "MAGOIVX" });
            DropIndex("dbo.PHIEUTIEM", new[] { "MABS" });
            DropIndex("dbo.PHIEUTIEM", new[] { "MAPHIEUKHAM" });
            DropIndex("dbo.CT_GOIVX", new[] { "MAVX" });
            DropIndex("dbo.CT_GOIVX", new[] { "MAGOIVX" });
            DropIndex("dbo.VACXIN", new[] { "MALOAI" });
            DropIndex("dbo.VACXIN", new[] { "MALO" });
            DropIndex("dbo.LOAIVACXIN", new[] { "MAKHO" });
            DropIndex("dbo.KHO", new[] { "MACS" });
            DropIndex("dbo.BACSI", new[] { "MACS" });
            DropIndex("dbo.BACSI", new[] { "IDTAIKHOAN" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.KHACHHANG");
            DropTable("dbo.PHIEUDANGKY");
            DropTable("dbo.PHIEUKHAM");
            DropTable("dbo.PHANQUYEN");
            DropTable("dbo.TAIKHOAN");
            DropTable("dbo.CT_PHIEUXUAT");
            DropTable("dbo.PHIEUXUAT");
            DropTable("dbo.NHASANXUAT");
            DropTable("dbo.LOVACXIN");
            DropTable("dbo.PHIEUNHAP");
            DropTable("dbo.NHANVIEN");
            DropTable("dbo.HOADON");
            DropTable("dbo.CT_PHIEUTIEM");
            DropTable("dbo.PHIEUTIEM");
            DropTable("dbo.GOIVACXIN");
            DropTable("dbo.CT_GOIVX");
            DropTable("dbo.VACXIN");
            DropTable("dbo.LOAIVACXIN");
            DropTable("dbo.KHO");
            DropTable("dbo.COSO");
            DropTable("dbo.BACSI");
        }
    }
}
