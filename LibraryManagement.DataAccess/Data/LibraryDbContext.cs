using LibraryManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccess
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options)
            :base(options) { }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<Adress>  Adresses { get; set; }

    }
}
