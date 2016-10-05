namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_LicensePaymentOrders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LicensePaymentOrders", "PaymentOrderType", c => c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false));
            AddColumn("dbo.LicensePaymentOrders", "UpgradeCredit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LicensePaymentOrders", "UpgradeCredit");
            DropColumn("dbo.LicensePaymentOrders", "PaymentOrderType");
        }
    }
}
