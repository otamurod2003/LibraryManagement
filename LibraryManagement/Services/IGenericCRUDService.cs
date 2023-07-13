using LibraryManagement.DataAccess;

namespace LibraryManagement.Services
{
    public interface IGenericCRUDService<T> where  T :class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T model);
        Task<T> Update(T model);
        Task<bool> Delete(int id);
    }
}
