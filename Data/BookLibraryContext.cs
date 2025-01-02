using Microsoft.EntityFrameworkCore;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Data
{
    public class BookLibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set;}
        public DbSet<Author> Authors { get; set;}

        public BookLibraryContext(DbContextOptions<BookLibraryContext> option)
            : base(option)
        {}
    }
}
