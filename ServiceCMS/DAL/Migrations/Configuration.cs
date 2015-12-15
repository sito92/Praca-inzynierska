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
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            SeedMenuButtons(context);
            SeedUsers(context);
            SeedNewsCategories(context);
            SeedSettings(context);
            SeedInsetArguments(context);
            SeedInset(context);
            SeedPage(context);
            SeedImages(context);

            SeedStatisticsInformation(context);
           // SeedServiceTypes(context);

           // SeedServiceTypes(context);
            SeedNewses(context);
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

        private void SeedNewses(ServiceCMSContext context)
        {
            context.Newses.AddOrUpdate(x => x.Title,
                new News() { Content = "TestNews1", Title = "TestNews1Title", CreationTimeStamp = DateTime.Now,AuthorId=1 },
                new News() { Content = "TestNews2", Title = "TestNews2Title", CreationTimeStamp = DateTime.Now, RestoreNewsId = 1, AuthorId = 1 },
                new News() { Content = "TestNews3", Title = "TestNews3Title", CreationTimeStamp = DateTime.Now, RestoreNewsId = 2, AuthorId = 1 },
                new News() { Content = "TestNews4", Title = "TestNews4Title", CreationTimeStamp = DateTime.Now, RestoreNewsId = 1, AuthorId = 1 },
                new News() { Content = "TestNews5", Title = "TestNews5Title", CreationTimeStamp = DateTime.Now, AuthorId = 1 }
                );
           context.SaveChanges();
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
                new Page() { Name = "Strona g³owna",Content="DUPA" },
                new Page() { Name = "Strona1", Content = "DUPA", RestorePageId=1 },
                new Page() { Name = "Strona2", Content = "DUPA", RestorePageId=2 },
                new Page() { Name = "Strona3", Content = "DUPA", RestorePageId=3 }

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
            context.ServiceTypes.AddOrUpdate(x => x.Name,
                new ServiceType() { Name = "Strzy¿enie mêskie" },
                new ServiceType() { Name = "Strzy¿enie damskie" }
                );
            context.SaveChanges();
        }

        private void SeedServiceProviders(ServiceCMSContext context)
        {
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
            #region Dates
            var dateOne = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            var dateSecond = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            var dateThird = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0);
            var dateFourth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0);
            var dateFifth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0);
            var dateSixt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);
            var dateSeventh = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0);
            #endregion
            context.RegistratedServices.AddOrUpdate(x => x.Id,
                new RegistratedService() { ServiceProviderId = 1, ServiceTypeId = 2, StartDate = dateOne },
                new RegistratedService() { ServiceProviderId = 1, ServiceTypeId = 1, StartDate = dateSecond},
                new RegistratedService() { ServiceProviderId = 2, ServiceTypeId = 2, StartDate = dateThird},
                new RegistratedService() { ServiceProviderId = 2, ServiceTypeId = 1, StartDate = dateFourth},
                new RegistratedService() { ServiceProviderId = 3, ServiceTypeId = 2, StartDate = dateFifth }
                );
            context.SaveChanges();
        }

        private void SeedServicePhrases(ServiceCMSContext context)
        {
            context.Phases.AddOrUpdate(x => x.Name,
                // Strzy¿enie damskie
                new ServicePhase() { Name = "Diagnoza F", DelayInMinutes = 0, DurationInMinutes = 10, Order = 1,ServiceTypeId = 2},
                new ServicePhase() { Name = "Strzy¿enie F", DelayInMinutes = 0, DurationInMinutes = 60, Order = 3, ServiceTypeId = 2 },
                new ServicePhase() { Name = "Modelowanie F", DelayInMinutes = 60, DurationInMinutes = 30, Order = 4, ServiceTypeId = 2 },
                new ServicePhase() { Name = "Farbowanie F", DelayInMinutes = 0, DurationInMinutes = 40, Order = 2, ServiceTypeId = 2 },
                 // Strzy¿enie mêskie
                new ServicePhase() { Name = "Diagnoza M", DelayInMinutes = 0, DurationInMinutes = 10, Order = 1, ServiceTypeId = 1 },
                new ServicePhase() { Name = "Strzy¿enie M", DelayInMinutes = 0, DurationInMinutes = 35, Order = 2, ServiceTypeId = 1 },
                new ServicePhase() { Name = "Modelowanie M", DelayInMinutes = 0, DurationInMinutes = 15, Order = 4, ServiceTypeId = 1 }
                );
            context.SaveChanges();
        }

        public void SeedStatisticsInformation(ServiceCMSContext context)
        {
            context.StatisticsInformations.AddRange(new List<StatisticsInformation>(){
                new StatisticsInformation(){ActionName = "Index", ControllerName = "News", IP = "168.145.123.100", Date = new DateTime(2015,10,1)},
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "24.232.0.0", Date = new DateTime(2015, 10, 11) },
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "23.91.160.0", Date = new DateTime(2015, 12, 1) },
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "24.232.0.0", Date = new DateTime(2015, 10, 11) },
                new StatisticsInformation() { ActionName = "Index", ControllerName = "News", IP = "23.91.160.0", Date = new DateTime(2013, 12, 1) },
                new StatisticsInformation(){ActionName = "Index", ControllerName = "News", IP = "168.145.113.100", Date = new DateTime(2015,11,1)}});
            context.SaveChanges();
        }
    }
}
