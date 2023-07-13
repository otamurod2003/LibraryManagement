using LibraryManagement.DataAccess.Data;
using LibraryManagement.DataAccess.Entities;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class AdressCRUDService : IGenericCRUDService<AdressModel>
    {
        private readonly IGenericRepository<AdressModel> _adressRepository;
        public AdressCRUDService(IGenericRepository<AdressModel> adressRepository)
        {
            _adressRepository = adressRepository;
        }

        public async Task<AdressModel> Create(AdressModel model)
        {
            var adress = new Adress
            {
                Id = model.Id,
                City = model.City,
                Country = model.Country,
                PostalCode = model.PostalCode,
            };
            var createdAdress = await Task.FromResult(_repository.Create());
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
