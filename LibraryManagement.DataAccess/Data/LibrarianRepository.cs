using LibraryManagement.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.DataAccess
{
    public class LibrarianRepository : IGenericRepository<Librarian>
    {
        private readonly LibraryDbContext _context;

        public LibrarianRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public Librarian Create(Librarian librarian)
        {
            if (librarian is not null)
            {
                _context.Librarians.Add(librarian);
                _context.SaveChanges();
                return librarian;
            }
            return librarian;

        }

        public async Task<bool> Delete(int id)
        {
            var librarian = await _context.Librarians.FirstOrDefaultAsync(lib => lib.Id == id);
            if (librarian != null)
            {
                _context.Librarians.Remove(librarian);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<Librarian>> GetAll()
        {
            return await Task.FromResult(_context.Librarians.ToList());
        }

        public async Task<Librarian> Get(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            return librarian;
        }

        public async Task<Librarian> Update(Librarian librarian)
        {
            var existLibrarian = _context.Librarians.Attach(librarian);
            existLibrarian.State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return librarian;
        }
    }
}
