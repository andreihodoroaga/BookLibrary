using BookLibraryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBackend.Data
{
    public class BookLibraryContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<BookLibrary> BookLibraries { get; set; }
        public DbSet<LibraryLocation> Locations { get; set; }

        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Author <-> Book (M-M)
            modelBuilder.Entity<AuthorBook>()
                .HasKey(ab => new { ab.AuthorId, ab.BookId });

            modelBuilder.Entity<AuthorBook>()
                .HasOne<Author>(ab => ab.Author)
                .WithMany(s => s.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId);

            modelBuilder.Entity<AuthorBook>()
                .HasOne<Book>(ab => ab.Book)
                .WithMany(s => s.AuthorBooks)
                .HasForeignKey(ab => ab.BookId);

            // Book <-> Library (M-M)
            modelBuilder.Entity<BookLibrary>()
               .HasKey(bl => new { bl.BookId, bl.LibraryId });

            modelBuilder.Entity<BookLibrary>()
                .HasOne<Book>(bl => bl.Book)
                .WithMany(s => s.BookLibraries)
                .HasForeignKey(bl => bl.BookId);

            modelBuilder.Entity<BookLibrary>()
                .HasOne<Library>(bl => bl.Library)
                .WithMany(s => s.BookLibraries)
                .HasForeignKey(bl => bl.LibraryId);

            // Library <-> LibraryLocation (O-O)
            modelBuilder.Entity<Library>()
                .HasOne<LibraryLocation>(l => l.Location)
                .WithOne(ll => ll.Library)
                .HasForeignKey<LibraryLocation>(ll => ll.LibraryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
