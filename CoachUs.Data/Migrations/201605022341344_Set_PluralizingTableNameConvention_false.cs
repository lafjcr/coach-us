namespace CoachUs.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_PluralizingTableNameConvention_false : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserDetail", newName: "UserDetails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.UserDetails", newName: "UserDetail");
        }
    }
}
