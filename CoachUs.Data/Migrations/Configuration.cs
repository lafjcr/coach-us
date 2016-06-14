namespace CoachUs.Data.Migrations
{
    using Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;

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
            #region Roles
            var adminRole = new Role
            {
                Id = "24c0707d-65cb-4132-8bf5-4553867807c0",
                Name = "Admin"
            };
            context.Roles.AddOrUpdate(
              adminRole,
              new Role
              {
                  Id = "71ee6a88-e893-49fd-96ea-69f46d225825",
                  Name = "Owner"
              },
              new Role
              {
                  Id = "8197518b-228b-41f9-b143-bfb8d7346db9",
                  Name = "Coach"
              },
              new Role
              {
                  Id = "bce8c54c-c2e5-44aa-9ab9-b1aa6b10a851",
                  Name = "Athlete"
              }
            );
            #endregion

            #region Admin User
            var adminUser = new User
            {
                Id = "1080a6a5-7f49-43b5-a74b-b8b19858e615",
                UserName = "admin@coachus.com",
                Email = "admin@coachus.com",
                PasswordHash = "AGxd3a+TeF3CNTr6PMh5kQiT4T8tKqgRlwXDANi4AExIQSG1QegV/IDxCOA3UyIcAw==",
                SecurityStamp = "9828d4db-cf13-49b9-a395-344bc00a5af4",                
            };            

            context.Users.AddOrUpdate(adminUser);

            context.UserRoles.AddOrUpdate(
                new IdentityUserRole
                {
                    UserId = adminUser.Id,
                    RoleId = adminRole.Id
                }
            );
            #endregion

            #region Licenses Packages and Prices
            var dateTimeNow = DateTime.UtcNow;
            var licensePackage = new LicensePackage()
            {
                Id = 1,
                Name = "CUTRIAL",
                Users = 25,
                MinUsers = 0,
                MaxUsers = 25,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackages.AddOrUpdate(licensePackage);

            dateTimeNow = DateTime.UtcNow;
            var licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 3,
                Price = 0,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);



            dateTimeNow = DateTime.UtcNow;
            licensePackage = new LicensePackage()
            {
                Id = 2,
                Name = "CU50",
                Users = 25,
                MinUsers = 0,
                MaxUsers = 50,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackages.AddOrUpdate(licensePackage);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 1,
                Price = 50,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 3,
                Price = 45,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 6,
                Price = 42.5M,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 12,
                Price = 40,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);



            dateTimeNow = DateTime.UtcNow;
            licensePackage = new LicensePackage()
            {
                Id = 3,
                Name = "CU100",
                Users = 25,
                MinUsers = 51,
                MaxUsers = 100,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackages.AddOrUpdate(licensePackage);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 1,
                Price = 45,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 3,
                Price = 40.5M,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 6,
                Price = 38.25M,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 12,
                Price = 36,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);



            dateTimeNow = DateTime.UtcNow;
            licensePackage = new LicensePackage()
            {
                Id = 4,
                Name = "CU150",
                Users = 25,
                MinUsers = 101,
                MaxUsers = 150,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackages.AddOrUpdate(licensePackage);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 1,
                Price = 42.5M,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 3,
                Price = 38.25M,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 6,
                Price = 36.13M,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 12,
                Price = 34,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);



            dateTimeNow = DateTime.UtcNow;
            licensePackage = new LicensePackage()
            {
                Id = 5,
                Name = "CUN",
                Users = 25,
                MinUsers = 151,
                MaxUsers = 1000,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackages.AddOrUpdate(licensePackage);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 1,
                Price = 40,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 3,
                Price = 36,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 6,
                Price = 34,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);

            dateTimeNow = DateTime.UtcNow;
            licensePackagePrice = new LicensePackagePrice()
            {
                LicensePackageId = licensePackage.Id,
                Months = 12,
                Price = 32,
                Active = true,
                CreatedDate = dateTimeNow,
                ModifiedDate = dateTimeNow
            };
            context.LicensePackagePrices.AddOrUpdate(licensePackagePrice);
            #endregion
        }
    }
}
