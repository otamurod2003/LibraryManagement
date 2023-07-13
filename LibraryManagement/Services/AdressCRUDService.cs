using LibraryManagement.DataAccess.Data;
using LibraryManagement.DataAccess.Entities;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LibraryManagement.Services
{
    public class AdressCRUDService : IGenericCRUDService<AdressModel>
    {
        private readonly IGenericRepository<Adress> _adressRepository;
        public AdressCRUDService(IGenericRepository<Adress> adressRepository)
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
            var createdAdress = await Task.FromResult(_adressRepository.Create(adress));
            var result = new AdressModel
            {
                Id = createdAdress.Id,
                City = createdAdress.City,
                Country = createdAdress.Country,
                PostalCode = createdAdress.PostalCode,
            };
            return result;
        }

       public async Task<bool> Delete(int id)
        {
            return await _adressRepository.Delete(id);    
        }

        public async Task<AdressModel> Get(int id)
        {
            var adress = await _adressRepository.Get(id);
            var adressModel = new AdressModel
            {
                Id = adress.Id,
                City = adress.City,
                Country = adress.Country,
                PostalCode = adress.PostalCode,

            };
            return adressModel;
        }

        public async Task<List<AdressModel>> GetAll()
        {
            var result = new List<AdressModel>();
            var adresses = await _adressRepository.GetAll();
            foreach( var adress in adresses)
            {
                var model = new AdressModel
                {
                    Id = adress.Id,
                    City = adress.City,
                    Country = adress.Country,
                    PostalCode = adress.PostalCode,
                };
                result.Add(model);
            }
            return result;
        }

        public async Task<AdressModel> Update(AdressModel model)
        {
            var adress = new Adress
            {
                Id = model.Id,
                City = model.City,
                PostalCode = model.PostalCode,
                Country = model.Country,
            };
            var existAdress = await _adressRepository.Update(adress);
            var result = new AdressModel
            {
                Id = existAdress.Id,
                City = existAdress.City,
                Country = existAdress.Country,
                PostalCode = existAdress.PostalCode,
            };

            return result;
        }

            
    }
}
