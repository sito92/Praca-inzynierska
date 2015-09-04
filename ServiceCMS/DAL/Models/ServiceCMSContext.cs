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
        public DbSet<News> News { get; set; } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>() //Encja News
                .HasRequired(x=>x.Author) // Ma wymaganego autora
                .WithMany() //Autor ma wiele newsów
                .HasForeignKey(x=>x.AuthorId) // News ma foreign key AuthorId
                .WillCascadeOnDelete(true); //Usuwając Autora usuwany jego newsy


            base.OnModelCreating(modelBuilder);
        }
    }
}
