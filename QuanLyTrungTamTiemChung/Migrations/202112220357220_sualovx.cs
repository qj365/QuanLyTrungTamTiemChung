namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sualovx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP");
            DropIndex("dbo.LOVACXIN", new[] { "MAPN" });
            AlterColumn("dbo.LOVACXIN", "MAPN", c => c.Int());
            CreateIndex("dbo.LOVACXIN", "MAPN");
            AddForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP", "MAPN");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP");
            DropIndex("dbo.LOVACXIN", new[] { "MAPN" });
            AlterColumn("dbo.LOVACXIN", "MAPN", c => c.Int(nullable: false));
            CreateIndex("dbo.LOVACXIN", "MAPN");
            AddForeignKey("dbo.LOVACXIN", "MAPN", "dbo.PHIEUNHAP", "MAPN", cascadeDelete: true);
        }
    }
}
