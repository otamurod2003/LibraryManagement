namespace LibraryManagement.DataAccess.Data
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        T Create(T model);
        Task<T> Update(T model);
        Task<bool> Delete(int id);
    }
}