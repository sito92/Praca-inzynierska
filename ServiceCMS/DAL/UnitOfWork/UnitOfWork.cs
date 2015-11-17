using DAL.Interfaces;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ServiceCMSContext context = new ServiceCMSContext();

        private GenericRepository<News> newsRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<NewsCategory> newsCategoryRepository;
        private GenericRepository<Settings> settingsRepository;
        private GenericRepository<NewsletterReceiver> newsletterReceiverRepository;
        private GenericRepository<Inset> insetRepository;
        private GenericRepository<Page> pageRepository;
        private GenericRepository<File> fileRepository;
        private GenericRepository<RegistratedService> registretedServiceRepository;
        private GenericRepository<StatisticsInformation> statisticsInformationRepository; 

        public GenericRepository<RegistratedService> RegistratedServiceRepository
        {
            get
            {

                if (this.registretedServiceRepository == null)
                {
                    this.registretedServiceRepository = new GenericRepository<RegistratedService>(context);
                }
                return registretedServiceRepository;
            }
        }
        public GenericRepository<File> FileRepository
        {
            get
            {

                if (this.fileRepository == null)
                {
                    this.fileRepository = new GenericRepository<File>(context);
                }
                return fileRepository;
            }
        }
        public GenericRepository<Inset> InsetRepository
        {
            get
            {

                if (this.insetRepository == null)
                {
                    this.insetRepository = new GenericRepository<Inset>(context);
                }
                return insetRepository;
            }
        }
        public GenericRepository<News> NewsRepository
        {
            get
            {

                if (this.newsRepository == null)
                {
                    this.newsRepository = new GenericRepository<News>(context);
                }
                return newsRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<NewsCategory> NewsCategoryRepository
        {
            get
            {
                if (this.newsCategoryRepository == null)
                {
                    this.newsCategoryRepository = new GenericRepository<NewsCategory>(context);
                }
                return newsCategoryRepository;
            }
        }

        public GenericRepository<Settings> SettingsRepository
        {
            get
            {
                if (this.settingsRepository == null)
                {
                    this.newsCategoryRepository = new GenericRepository<NewsCategory>(context);
                }
                return settingsRepository;
            }
            
        }

        public GenericRepository<NewsletterReceiver> NewsletterReceiverRepository
        {
            get
            {
                if (this.newsletterReceiverRepository == null)
                {
                    this.newsletterReceiverRepository = new GenericRepository<NewsletterReceiver>(context);
                }
                return newsletterReceiverRepository;
            }
        }
        public GenericRepository<Page> PageRepository
        {
            get
            {
                if (this.pageRepository == null)
                {
                    this.pageRepository = new GenericRepository<Page>(context);
                }
                return pageRepository;
            }
        }

        public GenericRepository<StatisticsInformation> StatisticInformationRepository
        {
            get
            {
                if (this.statisticsInformationRepository == null)
                {
                    this.statisticsInformationRepository = new GenericRepository<StatisticsInformation>(context);
                }
                return statisticsInformationRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
