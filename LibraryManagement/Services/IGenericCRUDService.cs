using LibraryManagement.DataAccess;

namespace LibraryManagement.Services
{
    public interface IGenericCRUDService<T> where  T :class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T adress);
        Task<T> Update(T adress);
        Task<bool> Delete(int id);
    }
}
