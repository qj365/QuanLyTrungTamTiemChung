namespace QuanLyTrungTamTiemChung.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intdecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CT_GOIVX", "LIEULUONG", c => c.Int());
            AlterColumn("dbo.CT_GOIVX", "DONGIA", c => c.Int());
            AlterColumn("dbo.CT_GOIVX", "THANHTIEN", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CT_GOIVX", "THANHTIEN", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.CT_GOIVX", "DONGIA", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.CT_GOIVX", "LIEULUONG", c => c.Decimal(precision: 18, scale: 0));
        }
    }
}
