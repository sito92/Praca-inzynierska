using System.CodeDom;
using DAL.Models;
using Modules.Cryptography;
using Modules.Cryptography.Interfaces;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.ServiceCMSContext>
    {
        private IPasswordManager _passwordManager;
        public Configuration()
        {

            _passwordManager = new PasswordManager(new HashComputer());
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.ServiceCMSContext context)
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
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            SeedUsers(context);
        }

        private void SeedUsers(ServiceCMSContext context)
        {
            IPasswordManager pManager = new PasswordManager(new HashComputer());
            string salt1;
            context.Users.AddOrUpdate(x => x.Login,
                new User() { Login = "test", Password = _passwordManager.GeneratePasswordHash("test", out salt1), Salt = salt1 }
                );
            context.SaveChanges();
        }
    }
}
