using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Data;
using LibraryManagement.DataAccess.Entities;
using LibraryManagement.Models;
namespace LibraryManagement.Services
{
    public class LibrarianCRUDService : IGenericCRUDService<LibrarianModel>
    {
        private readonly IGenericRepository<Librarian> _librarianRepository;
        private readonly IGenericRepository<Adress> _adressRepository;

        public LibrarianCRUDService(IGenericRepository<Librarian> librarianRepository, IGenericRepository<Adress> adressRepository)
        {
            _librarianRepository = librarianRepository;
            _adressRepository = adressRepository;
        }
        public async Task<LibrarianModel> Create(LibrarianModel model)
        {
            var existingAdress = await _adressRepository.Get(model.AdressId);
            var librarian = new Librarian
            {
                Id = model.Id,
                Age = model.Age,
                FullName = model.FullName,
                LibraryDepartment = (DataAccess.Departments)model.LibraryDepartment,
                
            };
            if(existingAdress != null)
                librarian.Adress = existingAdress;
            var createdLibrarian = await Task.FromResult(_librarianRepository.Create(librarian));
            var result = new LibrarianModel
            {
                Id = createdLibrarian.Id,
                FullName = createdLibrarian.FullName,
                Age = createdLibrarian.Age,
                LibraryDepartment = (Models.Departments)createdLibrarian.LibraryDepartment,
                AdressId = createdLibrarian.AdressId
            };
            return result;



        }

        public async Task<bool> Delete(int id)
        {
            var existingLibrarian = await _librarianRepository.Get(id);
            await _adressRepository.Delete(existingLibrarian.Adress.Id);
            return await _librarianRepository.Delete(id);
        }

        public async Task<LibrarianModel> Get(int id)
        {
            var librarian = await _librarianRepository.Get(id);
            var existLibrarianAdress = await _adressRepository.Get(librarian.Adress.Id);
            var model = new LibrarianModel
            {
                Id = librarian.Id,
                FullName = librarian.FullName,
                Age = librarian.Age,
                LibraryDepartment = (Models.Departments)librarian.LibraryDepartment,
                AdressId = librarian.AdressId
            };
            if (existLibrarianAdress != null)
                model.AdressId = existLibrarianAdress.Id;
            return model;
        }

        public async Task<List<LibrarianModel>> GetAll()
        {
            var result = new List<LibrarianModel>();
            var librarians = await _librarianRepository.GetAll();
            foreach (var librarian in librarians)
            {
                var model = new LibrarianModel
                {
                    FullName = librarian.FullName,
                    Age = librarian.Age,
                    LibraryDepartment = (Models.Departments)librarian.LibraryDepartment,
                    //PhotoFilePath = librarian.PhotoFilePath,
                    Id = librarian.Id,
                    AdressId = librarian.AdressId
                };

                result.Add(model);
            }
            return result;
        }

        public async Task<LibrarianModel> Update(LibrarianModel model)
        {
            var librarian = new Librarian
            {
                Id = model.Id,
                FullName = model.FullName,
                Age = model.Age,
                LibraryDepartment = (DataAccess.Departments)model.LibraryDepartment,
                AdressId = model.AdressId,
            };
            var updatedLibrarian = await _librarianRepository.Update(librarian);
            var result = new LibrarianModel
            {
                Id = updatedLibrarian.Id,
                FullName = updatedLibrarian.FullName,
                Age = updatedLibrarian.Age,
                LibraryDepartment = (Models.Departments)updatedLibrarian.LibraryDepartment,
                AdressId = updatedLibrarian.AdressId
            };

            return result;
        }


    }
}

