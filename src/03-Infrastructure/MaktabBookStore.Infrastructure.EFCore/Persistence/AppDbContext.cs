using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaktabBookStore.Domain.AuthorAgg.Entities;
using MaktabBookStore.Domain.BookAgg.Entities;
using MaktabBookStore.Domain.CategoryAgg.Entities;
using MaktabBookStore.Domain.UserAgg.Entities;
using MaktabBookStore.Infrastructure.EFCore.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MaktabBookStore.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        //public DbSet<AddedBooks> AddedBooks { get; set; }
        //public DbSet<BorrowedBooks> BorrowedBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=BookStoreDB;Trusted_Connection=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfigurations());
            modelBuilder.ApplyConfiguration(new BookConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
        }
    }
}
