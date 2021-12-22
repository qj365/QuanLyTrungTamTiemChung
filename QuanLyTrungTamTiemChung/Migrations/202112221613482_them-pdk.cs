namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thempdk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PHIEUKHAM", "MAPHIEUDK", "dbo.PHIEUDANGKY");
            AddForeignKey("dbo.PHIEUKHAM", "MAPHIEUDK", "dbo.PHIEUDANGKY", "MAPHIEUDK", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PHIEUKHAM", "MAPHIEUDK", "dbo.PHIEUDANGKY");
            AddForeignKey("dbo.PHIEUKHAM", "MAPHIEUDK", "dbo.PHIEUDANGKY", "MAPHIEUDK");
        }
    }
}
