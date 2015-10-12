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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>() //Encja News
                .HasRequired(x=>x.Author) // Ma wymaganego autora
                .WithMany() //Autor ma wiele newsów
                .HasForeignKey(x=>x.AuthorId) // News ma foreign key AuthorId
                .WillCascadeOnDelete(true); //Usuwając Autora usuwany jego newsy

            modelBuilder.Entity<News>()
                .HasMany(x => x.NewsCategories)
                .WithMany();


            modelBuilder.Entity<Inset>()
                .HasMany(x => x.Arguments)
                .WithMany();

            modelBuilder.Entity<Settings>()
                .HasRequired(x => x.DomainAndPorts)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServiceProvider>()
                .HasMany(x=>x.AvailableServvices)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegistratedService>()
                .HasRequired(x=>x.ServiceProvider)
                .WithMany()
                .WillCascadeOnDelete(true);
                
            modelBuilder.Entity<RegistratedService>()
                .HasRequired(x=>x.ServiceType)
                .WithMany()
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
