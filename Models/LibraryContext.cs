using KopiusLibrary.Models.Entities;
using KopiusLibrary.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace KopiusLibrary.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Branch> Branchs { get; set; }



        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentItem> DocumentItems { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tax> Taxs { get; set; }



        public DbSet<Auth> Auth { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Book>()
            //.HasMany(b => b.Authors)
            //.WithMany(a => a.Books)
            //.UsingEntity(j => j.ToTable("AuthorBook"));

            //modelBuilder.Entity<AuthorBook>()
            //    .HasKey(bg => bg.Id);


            //modelBuilder.Entity<AuthorBook>()
            //    .HasOne(ba => ba.Book)
            //    .WithMany(b => b.BookAuthors)
            //    .HasForeignKey(ba => ba.BookId);

            //modelBuilder.Entity<AuthorBook>()
            //    .HasOne(ba => ba.Author)
            //    .WithMany(a => a.BookAuthors)
            //    .HasForeignKey(ba => ba.AuthorId);


            //modelBuilder.Entity<BookGenre>()
            //    .HasKey(bg => bg.Id);

            //modelBuilder.Entity<BookGenre>()
            //    .HasOne(x => x.Genre)
            //    .WithMany(x => x.BookGenres)
            //    .HasForeignKey(x => x.GenreId);

            //modelBuilder.Entity<BookGenre>()
            //    .HasOne(x => x.Book)
            //    .WithMany(x => x.BookGenres)
            //    .HasForeignKey(x => x.BookId);

            

            // Overwrite to singular
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<Branch>().ToTable("Branch");
            modelBuilder.Entity<Discount>().ToTable("Discount");
            modelBuilder.Entity<Document>().ToTable("Document");
            modelBuilder.Entity<DocumentItem>().ToTable("DocumentItem");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentType");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Tax>().ToTable("Tax");
        }
    }
}
