namespace CoachUs.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Set_Indexes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(maxLength: 256,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Name",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IX_RoleName, IsUnique: True }", newValue: null)
                    },
                }));
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(maxLength: 256,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "UserName",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IX_UserName, IsUnique: True }", newValue: null)
                    },
                }));
            CreateIndex("dbo.AspNetRoles", "Name");
            CreateIndex("dbo.AspNetUsers", "UserName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "UserName" });
            DropIndex("dbo.AspNetRoles", new[] { "Name" });
            AlterColumn("dbo.AspNetUsers", "UserName", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "UserName",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_UserName, IsUnique: True }")
                    },
                }));
            AlterColumn("dbo.AspNetRoles", "Name", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Name",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_RoleName, IsUnique: True }")
                    },
                }));
        }
    }
}
