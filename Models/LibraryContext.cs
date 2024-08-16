using KopiusLibrary.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Auth> Auth { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // configurar relaciones ;

            // Overwrite to singular
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Auth>().ToTable("Auth");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Vendor>().ToTable("Vendors");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }
    }
}
