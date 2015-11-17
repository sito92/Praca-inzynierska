
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<News> NewsRepository { get; }
        GenericRepository<User> UserRepository { get; }
        GenericRepository<NewsCategory> NewsCategoryRepository { get; }
        GenericRepository<Settings> SettingsRepository { get; }
        GenericRepository<NewsletterReceiver> NewsletterReceiverRepository { get; }
        GenericRepository<Inset> InsetRepository { get; }
        GenericRepository<Page> PageRepository { get; }
        GenericRepository<File> FileRepository { get; }
        GenericRepository<RegistratedService> RegistratedServiceRepository { get; }
        GenericRepository<StatisticsInformation> StatisticInformationRepository { get; } 
        void Save();
    }
}
