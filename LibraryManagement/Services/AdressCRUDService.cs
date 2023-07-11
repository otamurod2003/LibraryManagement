using LibraryManagement.DataAccess.Data;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class AdressCRUDService : IGenericCRUDService<AdressModel>
    {
        private readonly IGenericRepository<AdressModel> _repository;
        public AdressCRUDService(IGenericRepository<AdressModel> repository)
        {
            _repository = repository;
        }

        public async Task<AdressModel> Create(AdressModel adress)
        {
            var createdAdress = await Task.FromResult(_repository.Create(adress));
            return createdAdress;   
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);    
        }

        public async Task<AdressModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdressModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AdressModel> Update(AdressModel librarian)
        {
            throw new NotImplementedException();
        }
    }
}
