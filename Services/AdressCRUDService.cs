using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Data;
using LibraryManagement.DataAccess.Entities;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Services
{
    public class AdressCRUDService : IGenericCRUDService<AdressModel>
    {
        private readonly IGenericRepository<AdressModel> _repository;
        public AdressCRUDService(IGenericRepository<AdressModel> repository)
        {
            _repository = repository;
        }

        public async Task<AdressModel> Create(AdressModel librarian)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
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
