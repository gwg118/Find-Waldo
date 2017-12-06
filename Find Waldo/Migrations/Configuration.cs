namespace Find_Waldo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Services;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Find_Waldo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Find_Waldo.Models.ApplicationDbContext";
        }

        protected override void Seed(Find_Waldo.Models.ApplicationDbContext context)
        {
            //Create instance of user store
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "Admin@findwaldo.com"))
            {
                var user = new ApplicationUser { UserName = "admin@findwaldo.com", Email = "admin@findwaldo.com" };
                userManager.Create(user, "passW0rd!");

                var service = new StaffServices(context);
                service.CreateStaff("admin", "user", user.Id);

                //create admin role
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });

                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }
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
        }
    }
}
