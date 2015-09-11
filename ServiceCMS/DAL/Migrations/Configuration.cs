using System.CodeDom;
using System.Net;
using System.Security;
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
            ////
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
            SeedUsers(context);
            SeedNewsCategories(context);
            SeedSettings(context);
            SeedInsetArguments(context);
            SeedInset(context);
            SeedPage(context);
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

        private void SeedSettings(ServiceCMSContext context)
        {
            //context.Settings.AddOrUpdate(x => x.EmailAddress,
            //    new Settings(){EmailAddress = "servicecmsthesis@gmail.com", EmailPassword = new NetworkCredential("cos", "arturikamil").SecurePassword});
            //context.SaveChanges();
        }

        private void SeedNewsCategories(ServiceCMSContext context)
        {
            context.NewsCategories.AddOrUpdate(x => x.Category,
                new NewsCategory() {Category = "Handlowy"});
            context.SaveChanges();
        }

        private void SeedInsetArguments(ServiceCMSContext context)
        {
            context.InsetArguments.AddOrUpdate(x=>x.Name,
                new InsetArgument() { IsRequierd = true,Name = "id",ArgumentType = 1},
                new InsetArgument() { IsRequierd = true, Name = "url", ArgumentType = 2}
                );
            context.SaveChanges();
        }
        private void SeedInset(ServiceCMSContext context)
        {
            
            var linkArguments = context.InsetArguments.Where(x => x.Id == 2);
            context.Insets.AddOrUpdate(x=>x.Name,
                new Inset() { Name = "externalLink",Arguments = linkArguments.ToList()}
                
                );
            context.Insets.AddOrUpdate(x=>x.Name,
               new Inset() { Name = "localLink", Arguments = linkArguments.ToList() }

               );
            context.SaveChanges();
        }

        private void SeedPage(ServiceCMSContext context)
        {
            context.Page.AddOrUpdate(x=>x.Name,
                new Page() {Name = "Strona g³owna"},
                new Page() { Name = "Strona1"},
                new Page() { Name = "Strona2"},
                new Page() { Name = "Strona3"}
                
                );
            context.SaveChanges();
        }
    }
}
