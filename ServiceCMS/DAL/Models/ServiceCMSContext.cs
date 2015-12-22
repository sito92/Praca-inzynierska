using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ServiceCMSContext:DbContext
    {
        public ServiceCMSContext()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<News> Newses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<NewsletterReceiver> NewslettersReceivers { get; set; }
        public DbSet<InsetArgument> InsetArguments { get; set; }
        public DbSet<Inset> Insets { get; set; }
        public DbSet<DomainAndPorts> DomainAndPorts { get; set; } 
        public DbSet<Page> Page { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceProvider> ServiceProviders { get; set; }
        public DbSet<RegistratedService> RegistratedServices { get; set; }
        public DbSet<ServicePhase> Phases { get; set; }
        public DbSet<StatisticsInformation> StatisticsInformations { get; set; }
        public DbSet<MenuButton> MenuButtons { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<News>()
                .HasMany(x => x.NewsCategories)
                .WithMany();


            modelBuilder.Entity<Inset>()
                .HasMany(x => x.Arguments)
                .WithMany();

            modelBuilder.Entity<ServiceProvider>()
                            .HasMany(x => x.AvailableServices)
                            .WithMany(x=>x.ServiceProviders);

            modelBuilder.Entity<RegistratedService>()
                .HasRequired(x=>x.ServiceProvider)
                .WithMany()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<RegistratedService>()
                .HasRequired(x=>x.ServiceType)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ServiceType>()
                .HasMany(x => x.Phases)
                .WithRequired(x => x.ServiceType)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MenuButton>()
                .HasMany(x => x.Children)
                .WithOptional(x => x.Parent)
                .HasForeignKey(x=>x.ParentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Page>()
                .HasMany(x => x.Media)
                .WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
