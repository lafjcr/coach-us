namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_UserDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        BirthDate = c.DateTime(),
                        Gender = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Laterality = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Country = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDetails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserDetails", new[] { "UserId" });
            DropTable("dbo.UserDetails");
        }
    }
}
