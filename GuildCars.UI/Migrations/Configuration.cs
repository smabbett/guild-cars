namespace GuildCars.UI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Load the user and role managers with our custom models
            try
            {
                var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
                var roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));    

                if (!context.Roles.Any(r => r.Name == "admin"))
                {             
                    var role = new IdentityRole { Name = "admin" };
                    roleMgr.Create(role);
                }
                if (!context.Roles.Any(r => r.Name == "sales"))
                {
                    var role = new IdentityRole { Name = "sales" };
                    roleMgr.Create(role);
                }
                if (!context.Roles.Any(r => r.Name == "disabled"))
                {
                    var role = new IdentityRole { Name = "disabled" };
                    roleMgr.Create(role);
                }

                if (!context.Users.Any(u => u.UserName == "admin@test.com"))
                {          
                    var user = new AppUser { UserName = "admin@test.com" };

                    userMgr.Create(user, "Testing123!");
                    userMgr.AddToRole(user.Id, "admin");
                }         
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
