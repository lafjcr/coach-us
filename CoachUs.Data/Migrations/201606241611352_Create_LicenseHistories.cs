namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_LicenseHistories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LicenseHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicenseId = c.Int(nullable: false),
                        LicensePackagePriceId = c.Int(nullable: false),
                        MaxUsers = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
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
            DropForeignKey("dbo.LicenseHistories", "LicensePackagePriceId", "dbo.LicensePackagePrices");
            DropForeignKey("dbo.LicenseHistories", "LicenseId", "dbo.Licenses");
            DropIndex("dbo.LicenseHistories", new[] { "LicensePackagePriceId" });
            DropIndex("dbo.LicenseHistories", new[] { "LicenseId" });
            DropTable("dbo.LicenseHistories");
        }
    }
}
