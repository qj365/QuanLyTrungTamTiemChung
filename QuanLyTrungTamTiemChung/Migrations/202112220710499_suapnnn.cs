namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suapnnn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PHIEUNHAP", "NGAYNHAP", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PHIEUNHAP", "NGAYNHAP", c => c.DateTime(nullable: false));
        }
    }
}
