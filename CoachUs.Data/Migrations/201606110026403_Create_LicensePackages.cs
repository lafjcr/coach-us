namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_LicensePackages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LicensePackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Users = c.Int(nullable: false),
                        MinUsers = c.Int(nullable: false),
                        MaxUsers = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LicensePackages");
        }
    }
}
