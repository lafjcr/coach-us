namespace CoachUs.Data.Migrations
{
    using Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoachUs.Data.CoachUsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoachUs.Data.CoachUsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var adminRole = new IdentityRole
            {
                Id = "24c0707d-65cb-4132-8bf5-4553867807c0",
                Name = "Admin"
            };
            context.Roles.AddOrUpdate(
              adminRole,
              new IdentityRole
              {
                  Id = "71ee6a88-e893-49fd-96ea-69f46d225825",
                  Name = "Owner"
              },
              new IdentityRole
              {
                  Id = "8197518b-228b-41f9-b143-bfb8d7346db9",
                  Name = "Coach"
              },
              new IdentityRole
              {
                  Id = "bce8c54c-c2e5-44aa-9ab9-b1aa6b10a851",
                  Name = "Athlete"
              }
            );

            var adminUser = new User
            {
                Id = "1080a6a5-7f49-43b5-a74b-b8b19858e615",
                UserName = "admin@coachus.com",
                Email = "admin@coachus.com",
                PasswordHash = "AGxd3a+TeF3CNTr6PMh5kQiT4T8tKqgRlwXDANi4AExIQSG1QegV/IDxCOA3UyIcAw==",
                SecurityStamp = "9828d4db-cf13-49b9-a395-344bc00a5af4",                
            };            

            context.Users.AddOrUpdate(adminUser);

            context.UserRoles.Add(
                new IdentityUserRole
                {
                    UserId = adminUser.Id,
                    RoleId = adminRole.Id
                }
            );
        }
    }
}
