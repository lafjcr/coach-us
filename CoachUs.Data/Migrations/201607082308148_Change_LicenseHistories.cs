namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_LicenseHistories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LicenseHistories", "LicensePaymentOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.LicenseHistories", "LicensePaymentOrderId");
            AddForeignKey("dbo.LicenseHistories", "LicensePaymentOrderId", "dbo.LicensePaymentOrders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LicenseHistories", "LicensePaymentOrderId", "dbo.LicensePaymentOrders");
            DropIndex("dbo.LicenseHistories", new[] { "LicensePaymentOrderId" });
            DropColumn("dbo.LicenseHistories", "LicensePaymentOrderId");
        }
    }
}
