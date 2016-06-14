namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_LicensePackagePrices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LicensePackagePrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicensePackageId = c.Int(nullable: false),
                        Months = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicensePackages", t => t.LicensePackageId, cascadeDelete: true)
                .Index(t => t.LicensePackageId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LicensePackagePrices", "LicensePackageId", "dbo.LicensePackages");
            DropIndex("dbo.LicensePackagePrices", new[] { "LicensePackageId" });
            DropTable("dbo.LicensePackagePrices");
        }
    }
}
