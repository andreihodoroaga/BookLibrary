using BookLibraryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Data
{
    public class BooksLibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<BookLibrary> BookLibraries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public BooksLibraryContext(DbContextOptions<BooksLibraryContext> options) : base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Book <-> Library (M-M)
            modelBuilder.Entity<BookLibrary>()
               .HasKey(bl => new { bl.BookId, bl.LibraryId });

            // Library <-> Location (O-O)
            modelBuilder.Entity<Location>()
                .HasOne(l => l.Library)
                .WithOne(ll => ll.Location)
                .HasForeignKey<Library>(ll => ll.LocationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
