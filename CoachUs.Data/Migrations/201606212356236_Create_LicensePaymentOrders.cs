namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_LicensePaymentOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LicensePaymentOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseId = c.Int(nullable: false),
                        LicensePackagePriceId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Users = c.Int(nullable: false),
                        UnitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidDate = c.DateTime(),
                        PaymentType = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        PaymentReference = c.String(),
                        PaymentConfirmed = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licenses", t => t.LicenseId, cascadeDelete: true)
                .ForeignKey("dbo.LicensePackagePrices", t => t.LicensePackagePriceId, cascadeDelete: true)
                .Index(t => t.LicenseId)
                .Index(t => t.LicensePackagePriceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LicensePaymentOrders", "LicensePackagePriceId", "dbo.LicensePackagePrices");
            DropForeignKey("dbo.LicensePaymentOrders", "LicenseId", "dbo.Licenses");
            DropIndex("dbo.LicensePaymentOrders", new[] { "LicensePackagePriceId" });
            DropIndex("dbo.LicensePaymentOrders", new[] { "LicenseId" });
            DropTable("dbo.LicensePaymentOrders");
        }
    }
}
