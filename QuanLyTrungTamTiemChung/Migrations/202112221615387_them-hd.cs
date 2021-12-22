namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themhd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HOADON", "MAPHIEUTIEM", "dbo.PHIEUTIEM");
            DropForeignKey("dbo.PHIEUTIEM", "MAPHIEUKHAM", "dbo.PHIEUKHAM");
            AddForeignKey("dbo.HOADON", "MAPHIEUTIEM", "dbo.PHIEUTIEM", "MAPHIEUTIEM", cascadeDelete: true);
            AddForeignKey("dbo.PHIEUTIEM", "MAPHIEUKHAM", "dbo.PHIEUKHAM", "MAPHIEUKHAM", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PHIEUTIEM", "MAPHIEUKHAM", "dbo.PHIEUKHAM");
            DropForeignKey("dbo.HOADON", "MAPHIEUTIEM", "dbo.PHIEUTIEM");
            AddForeignKey("dbo.PHIEUTIEM", "MAPHIEUKHAM", "dbo.PHIEUKHAM", "MAPHIEUKHAM");
            AddForeignKey("dbo.HOADON", "MAPHIEUTIEM", "dbo.PHIEUTIEM", "MAPHIEUTIEM");
        }
    }
}
