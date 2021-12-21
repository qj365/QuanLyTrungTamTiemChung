namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_tencoso : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.COSO", "TENCS", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.COSO", "TENCS", c => c.String(maxLength: 50));
        }
    }
}
