namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suapn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PHIEUNHAP", "TONGTIEN", c => c.Decimal(precision: 18, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PHIEUNHAP", "TONGTIEN", c => c.Decimal(nullable: false, precision: 18, scale: 0));
        }
    }
}
