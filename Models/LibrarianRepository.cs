using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LibraryManagement.Models
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly LibraryDbContext _context;

        public LibrarianRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<Librarian> CreateLibrarian(Librarian librarian)
        {
            _context.Librarians.Add(librarian);
            await _context.SaveChangesAsync();
            return librarian;

        }

        public async Task<Librarian> DeleteLibrarian(int id)
        {
            var librarian = await _context.Librarians.FirstOrDefaultAsync(lib => lib.Id == id);
            if (librarian != null)
                _context.Librarians.Remove(librarian);
            await _context.SaveChangesAsync();
            return librarian;
        }

        public async Task<List<Librarian>> GetAllLibrarians()
        {
            return await Task.FromResult(_context.Librarians.ToList());
        }

        public async Task<Librarian> GetLibrarian(int id)
        {
            var librarian = await _context.Librarians.FindAsync(id);
            return librarian;
        }

        public async Task<Librarian> UpdateLibrarian(Librarian librarian)
        {
            var existLibrarian = _context.Librarians.Attach(librarian);
            existLibrarian.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return librarian;
        }
    }
}
