using AWSPluralSightDemo.DomainClasses;

namespace AWSPluralSightDemo.Data;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author {AuthorId = 1, Name = "Mico Yuk"},
            new Author {AuthorId = 2, Name = "Arlan Hamilton"},
            new Author {AuthorId = 3, Name = "Minda Harts"},
            new Author {AuthorId = 4, Name = "Susanne Tedrick"},
            new Author {AuthorId = 5, Name = "Abisoye Ajayi-Akinfolarin"},
            new Author {AuthorId = 6, Name = "Kesha Williams"});
        modelBuilder.Entity<Book>().HasData(
            new Book {BookId = 1, AuthorId = 1, Title = "Data Visualization for Dummies"},
            new Book {BookId = 2, AuthorId = 2, Title = "It's About Damn Time"},
            new Book {BookId = 3, AuthorId = 3, Title = "The Memo"},
            new Book {BookId = 4, AuthorId = 4, Title = "Women of Color in Tech"},
            new Book {BookId = 5, AuthorId = 5, Title = "I WOKE UP AT 30: How I Utilised Inertia for Global Impact"},
            new Book {BookId = 6, AuthorId = 6, Title = "No books but check out her Pluralsight courses!"}
        );
    }
}