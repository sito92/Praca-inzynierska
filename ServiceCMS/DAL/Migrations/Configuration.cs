using System.CodeDom;
using System.Collections.Generic;
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
            SeedMenuButtons(context);
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
            SeedImages(context);

            SeedStatisticsInformation(context);
            SeedServiceTypes(context);


            SeedServiceProviders(context);
            SeedServicePhrases(context);
            SeedRegistratedServices(context);
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

        private void SeedMenuButtons(ServiceCMSContext context)
        {
            context.MenuButtons.AddOrUpdate(x => x.Content,new Models.MenuButton(){Content = "rodzic"});
            context.SaveChanges();

            context.MenuButtons.AddOrUpdate(x => x.Content,
                new Models.MenuButton(){Content = "dziecko1", ParentId = 1},
                new Models.MenuButton(){Content = "dziecko2", ParentId = 1},
                new Models.MenuButton(){Content = "dziecko11",ParentId = 2},
                new Models.MenuButton(){Content = "dziecko111",ParentId = 4});
            context.SaveChanges();
        }

        private void SeedNewsCategories(ServiceCMSContext context)
        {
            context.NewsCategories.AddOrUpdate(x => x.Category,
                new NewsCategory() { Category = "Handlowy" });
            context.SaveChanges();
        }

        private void SeedInsetArguments(ServiceCMSContext context)
        {
            context.InsetArguments.AddOrUpdate(x => x.Name,
                new InsetArgument() { IsRequierd = true, Name = "id", ArgumentType = 1 },
                new InsetArgument() { IsRequierd = true, Name = "url", ArgumentType = 2 },
                new InsetArgument() { IsRequierd = false, Name = "text", ArgumentType = 2 },
                new InsetArgument() { IsRequierd = true, Name = "ids", ArgumentType = 3 }
                );
            context.SaveChanges();
        }
        private void SeedInset(ServiceCMSContext context)
        {

            //var linkArguments = context.InsetArguments.Where(x => x.Id == 2);
            context.Insets.AddOrUpdate(x => x.Name,
                new Inset() { Name = "localLink", Arguments = context.InsetArguments.Where(x => x.Name == "id" || x.Name == "text").ToList() }

                );
            context.Insets.AddOrUpdate(x => x.Name,
               new Inset() { Name = "externalLink", Arguments = context.InsetArguments.Where(x => x.Name == "url" || x.Name == "text").ToList() }

               );
            context.Insets.AddOrUpdate(x => x.Name,
                new Inset() { Name = "images", Arguments = context.InsetArguments.Where(x => x.Name == "ids").ToList() }

               );
            context.SaveChanges();
        }

        private void SeedPage(ServiceCMSContext context)
        {
            context.Page.AddOrUpdate(x => x.Name,
                new Page() { Name = "Strona g³owna" },
                new Page() { Name = "Strona1" },
                new Page() { Name = "Strona2" },
                new Page() { Name = "Strona3" }

                );
            context.SaveChanges();
        }

        private void SeedImages(ServiceCMSContext context)
        {
            context.Files.AddOrUpdate(x => x.Name,
                new File() { Name = "Plik 1", Extension = ".jpg", FileType = 1, Path = "C:/obrazek.jpg" },
                new File() { Name = "Ulubiony obrazek", Extension = ".jpg", FileType = 1, Path = "C:/obraeksdfsd.jpg" },
                new File() { Name = "Inny picture", Extension = ".jpg", FileType = 1, Path = "C:/obrasdzek.jpg" },
                new File() { Name = "T³o", Extension = ".jpg", FileType = 1, Path = "C:/tlo.jpg" },
                new File() { Name = "Do newsa", Extension = ".jpg", FileType = 1, Path = "C:/news.jpg" }
                );
        }

        private void SeedServiceTypes(ServiceCMSContext context)
        {
            //context.ServiceTypes.AddOrUpdate(x => x.Name,
            //    new ServiceType() { Name = "Strzy¿enie mêskie" },
            //    new ServiceType() { Name = "Strzy¿enie damskie" }
            //    );
            //context.SaveChanges();
        }

        private void SeedServiceProviders(ServiceCMSContext context)
        {
            //var sampleServiceTypes = context.ServiceTypes.Where(x => x.Id == 1 || x.Id == 2);
            //context.ServiceProviders.AddOrUpdate(x => x.Name,
            //    new ServiceProvider() { Name = "Pani Krysia", AvailableServices = new List<ServiceType>() },
            //    new ServiceProvider() { Name = "Pan Marek", AvailableServices = new List<ServiceType>() },
            //    new ServiceProvider() { Name = "st. spec. Zenos³aw", AvailableServices = new List<ServiceType>()}
            //    );

            var a = new ServiceProvider() { Name = "Pani Krysia", AvailableServices = new List<ServiceType>() };
            var b = new ServiceProvider() { Name = "Pan Marek", AvailableServices = new List<ServiceType>() };
            var c = new ServiceProvider() { Name = "st. spec. Zenos³aw", AvailableServices = new List<ServiceType>() };

            var firstType = new ServiceType() { Name = "Strzy¿enie mêskie" };
            var secondType = new ServiceType() { Name = "Strzy¿enie damskie" };
            a.AvailableServices.Add(firstType);
            a.AvailableServices.Add(secondType);
            b.AvailableServices.Add(firstType);
            c.AvailableServices.Add(secondType);

           context.ServiceProviders.AddOrUpdate(x => x.Name, a, b, c);
            context.SaveChanges();
        }

        private void SeedRegistratedServices(ServiceCMSContext context)
        {
            context.RegistratedServices.AddOrUpdate(x => x.Id,
                new RegistratedService() { ServiceProviderId = 1, ServiceTypeId = 1, StartDate = DateTime.Now.AddDays(1) },
                new RegistratedService() { ServiceProviderId = 1, ServiceTypeId = 1, StartDate = DateTime.Now.AddDays(2) },
                new RegistratedService() { ServiceProviderId = 2, ServiceTypeId = 2, StartDate = DateTime.Now.AddDays(3) },
                new RegistratedService() { ServiceProviderId = 2, ServiceTypeId = 1, StartDate = DateTime.Now.AddDays(1) },
                new RegistratedService() { ServiceProviderId = 3, ServiceTypeId = 2, StartDate = DateTime.Now.AddDays(1) }
                );
            context.SaveChanges();
        }

        private void SeedServicePhrases(ServiceCMSContext context)
        {
            context.Phases.AddOrUpdate(x => x.Name,
                // Strzy¿enie damskie
                new ServicePhase() { Name = "Diagnoza", DelayInSeconds = 0, DurationInSeconds = 600, Order = 1,ServiceTypeId = 2},
                new ServicePhase() { Name = "Strzy¿enie", DelayInSeconds = 0, DurationInSeconds = 1800, Order = 3, ServiceTypeId = 2 },
                new ServicePhase() { Name = "Modelowanie", DelayInSeconds = 0, DurationInSeconds = 300, Order = 4, ServiceTypeId = 2 },
                new ServicePhase() { Name = "Farbowanie", DelayInSeconds = 1800, DurationInSeconds = 900, Order = 2, ServiceTypeId = 2 },

                 // Strzy¿enie mêskie
                new ServicePhase() { Name = "Diagnoza", DelayInSeconds = 0, DurationInSeconds = 600, Order = 1,ServiceTypeId = 1},
                new ServicePhase() { Name = "Strzy¿enie", DelayInSeconds = 0, DurationInSeconds = 1200, Order = 2, ServiceTypeId = 1 },
                new ServicePhase() { Name = "Modelowanie", DelayInSeconds = 0, DurationInSeconds = 300, Order = 4, ServiceTypeId = 1 }
                );
            context.SaveChanges();
        }

        public void SeedStatisticsInformation(ServiceCMSContext context)
        {
            context.StatisticsInformations.AddOrUpdate(x=> x.IP,
                new StatisticsInformation(){ActionName = "Index", ControllerName = "News", IP = "168.145.123.100", Date = new DateTime(2015,10,1)},
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "24.232.0.0", Date = new DateTime(2015, 10, 11) },
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "23.91.160.0", Date = new DateTime(2015, 12, 1) },
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "24.232.0.0", Date = new DateTime(2015, 10, 11) },
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "23.91.160.0", Date = new DateTime(2013, 12, 1) },
                new StatisticsInformation(){ActionName = "Index", ControllerName = "News", IP = "168.145.113.100", Date = new DateTime(2015,11,1)});
            context.SaveChanges();
        }
    }
}
