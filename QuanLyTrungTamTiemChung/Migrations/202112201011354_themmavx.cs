namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themmavx : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.LOVACXIN", name: "VACXIN_MAVX", newName: "MAVX");
            RenameIndex(table: "dbo.LOVACXIN", name: "IX_VACXIN_MAVX", newName: "IX_MAVX");
            DropColumn("dbo.VACXIN", "MALO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VACXIN", "MALO", c => c.Int());
            RenameIndex(table: "dbo.LOVACXIN", name: "IX_MAVX", newName: "IX_VACXIN_MAVX");
            RenameColumn(table: "dbo.LOVACXIN", name: "MAVX", newName: "VACXIN_MAVX");
        }
    }
}
