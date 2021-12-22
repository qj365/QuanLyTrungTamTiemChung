namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datsua : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KHO", "MACS", "dbo.COSO");
            DropForeignKey("dbo.LOVACXIN", "MAVX", "dbo.VACXIN");
            DropForeignKey("dbo.PHIEUNHAP", "MANV", "dbo.NHANVIEN");
            DropForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP");
            DropForeignKey("dbo.PHIEUNHAP", "MANSX", "dbo.NHASANXUAT");
            DropIndex("dbo.KHO", new[] { "MACS" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANSX" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANV" });
            DropIndex("dbo.LOVACXIN", new[] { "MAPN" });
            DropIndex("dbo.LOVACXIN", new[] { "MAVX" });
            AlterColumn("dbo.COSO", "TENCS", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KHO", "TENKHO", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KHO", "SDT", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AlterColumn("dbo.KHO", "DIACHI", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KHO", "MACS", c => c.Int(nullable: false));
            AlterColumn("dbo.PHIEUNHAP", "NGAYNHAP", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.PHIEUNHAP", "TONGTIEN", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.PHIEUNHAP", "MANSX", c => c.Int(nullable: false));
            AlterColumn("dbo.PHIEUNHAP", "MANV", c => c.Int(nullable: false));
            AlterColumn("dbo.LOVACXIN", "SOLUONG", c => c.Int(nullable: false));
            AlterColumn("dbo.LOVACXIN", "DONGIA", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.LOVACXIN", "THANHTIEN", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.LOVACXIN", "MAPN", c => c.Int(nullable: false));
            AlterColumn("dbo.LOVACXIN", "MAVX", c => c.Int(nullable: false));
            AlterColumn("dbo.NHASANXUAT", "TENNSX", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.NHASANXUAT", "DIACHI", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.NHASANXUAT", "SDT", c => c.String(nullable: false, maxLength: 15, unicode: false));
            CreateIndex("dbo.KHO", "MACS");
            CreateIndex("dbo.PHIEUNHAP", "MANSX");
            CreateIndex("dbo.PHIEUNHAP", "MANV");
            CreateIndex("dbo.LOVACXIN", "MAPN");
            CreateIndex("dbo.LOVACXIN", "MAVX");
            AddForeignKey("dbo.KHO", "MACS", "dbo.COSO", "MACS", cascadeDelete: true);
            AddForeignKey("dbo.LOVACXIN", "MAVX", "dbo.VACXIN", "MAVX", cascadeDelete: true);
            AddForeignKey("dbo.PHIEUNHAP", "MANV", "dbo.NHANVIEN", "MANV", cascadeDelete: true);
            AddForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP", "MAPN", cascadeDelete: true);
            AddForeignKey("dbo.PHIEUNHAP", "MANSX", "dbo.NHASANXUAT", "MANSX", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PHIEUNHAP", "MANSX", "dbo.NHASANXUAT");
            DropForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP");
            DropForeignKey("dbo.PHIEUNHAP", "MANV", "dbo.NHANVIEN");
            DropForeignKey("dbo.LOVACXIN", "MAVX", "dbo.VACXIN");
            DropForeignKey("dbo.KHO", "MACS", "dbo.COSO");
            DropIndex("dbo.LOVACXIN", new[] { "MAVX" });
            DropIndex("dbo.LOVACXIN", new[] { "MAPN" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANV" });
            DropIndex("dbo.PHIEUNHAP", new[] { "MANSX" });
            DropIndex("dbo.KHO", new[] { "MACS" });
            AlterColumn("dbo.NHASANXUAT", "SDT", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.NHASANXUAT", "DIACHI", c => c.String(maxLength: 50));
            AlterColumn("dbo.NHASANXUAT", "TENNSX", c => c.String(maxLength: 50));
            AlterColumn("dbo.LOVACXIN", "MAVX", c => c.Int());
            AlterColumn("dbo.LOVACXIN", "MAPN", c => c.Int());
            AlterColumn("dbo.LOVACXIN", "THANHTIEN", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.LOVACXIN", "DONGIA", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.LOVACXIN", "SOLUONG", c => c.Int());
            AlterColumn("dbo.PHIEUNHAP", "MANV", c => c.Int());
            AlterColumn("dbo.PHIEUNHAP", "MANSX", c => c.Int());
            AlterColumn("dbo.PHIEUNHAP", "TONGTIEN", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.PHIEUNHAP", "NGAYNHAP", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.KHO", "MACS", c => c.Int());
            AlterColumn("dbo.KHO", "DIACHI", c => c.String(maxLength: 50));
            AlterColumn("dbo.KHO", "SDT", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.KHO", "TENKHO", c => c.String(maxLength: 50));
            AlterColumn("dbo.COSO", "TENCS", c => c.String(maxLength: 50));
            CreateIndex("dbo.LOVACXIN", "MAVX");
            CreateIndex("dbo.LOVACXIN", "MAPN");
            CreateIndex("dbo.PHIEUNHAP", "MANV");
            CreateIndex("dbo.PHIEUNHAP", "MANSX");
            CreateIndex("dbo.KHO", "MACS");
            AddForeignKey("dbo.PHIEUNHAP", "MANSX", "dbo.NHASANXUAT", "MANSX");
            AddForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP", "MAPN");
            AddForeignKey("dbo.PHIEUNHAP", "MANV", "dbo.NHANVIEN", "MANV");
            AddForeignKey("dbo.LOVACXIN", "MAVX", "dbo.VACXIN", "MAVX");
            AddForeignKey("dbo.KHO", "MACS", "dbo.COSO", "MACS");
        }
    }
}
