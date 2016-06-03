namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetails_Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDetails", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.UserDetails", "Gender", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
            AlterColumn("dbo.UserDetails", "Laterality", c => c.String(maxLength: 1, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDetails", "Laterality", c => c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false));
            AlterColumn("dbo.UserDetails", "Gender", c => c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false));
            AlterColumn("dbo.UserDetails", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
