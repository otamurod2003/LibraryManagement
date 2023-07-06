using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options)
            :base(options) { }
        public DbSet<Librarian> Librarians { get; set; }

    }
}
