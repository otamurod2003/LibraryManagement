namespace LibraryManagement.Models
{
    public interface ILibrarianRepository
    {
        Task<List<Librarian>> GetAllLibrarians();
        Task<Librarian> GetLibrarian(int id);
        Task<Librarian> CreateLibrarian(Librarian librarian);
        Task<Librarian> UpdateLibrarian(Librarian librarian);
        Task<Librarian> DeleteLibrarian(int id);
    }
}
