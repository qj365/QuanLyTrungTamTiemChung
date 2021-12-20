namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lovxvx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VACXIN", "MALO", "dbo.LOVACXIN");
            DropIndex("dbo.VACXIN", new[] { "MALO" });
            AddColumn("dbo.LOVACXIN", "VACXIN_MAVX", c => c.Int());
            CreateIndex("dbo.LOVACXIN", "VACXIN_MAVX");
            AddForeignKey("dbo.LOVACXIN", "VACXIN_MAVX", "dbo.VACXIN", "MAVX");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LOVACXIN", "VACXIN_MAVX", "dbo.VACXIN");
            DropIndex("dbo.LOVACXIN", new[] { "VACXIN_MAVX" });
            DropColumn("dbo.LOVACXIN", "VACXIN_MAVX");
            CreateIndex("dbo.VACXIN", "MALO");
            AddForeignKey("dbo.VACXIN", "MALO", "dbo.LOVACXIN", "MALO");
        }
    }
}
