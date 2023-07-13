using LibraryManagement.DataAccess;
using LibraryManagement.DataAccess.Data;
using LibraryManagement.Models;
namespace LibraryManagement.Services
{
    public class LibrarianCRUDService : IGenericCRUDService<LibrarianModel>
    {
        private readonly IGenericRepository<Librarian> _librarianRepository;

        public LibrarianCRUDService(IGenericRepository<Librarian> librarianRepository)
        {
            _librarianRepository = librarianRepository;
        }
        public async Task<LibrarianModel> Create(LibrarianModel model)
        {
            var librarian = new Librarian
            {
                Id = model.Id,
                Age = model.Age,
                FullName = model.FullName,
                LibraryDepartment = (DataAccess.Departments)model.LibraryDepartment,
                AdressId = model.AdressId,
            };
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
            return await _librarianRepository.Delete(id);
        }

        public async Task<LibrarianModel> Get(int id)
        {
            var librarian = await _librarianRepository.Get(id);
            var model = new LibrarianModel
            {
                Id = librarian.Id,
                FullName = librarian.FullName,
                Age = librarian.Age,
                LibraryDepartment = (Models.Departments)librarian.LibraryDepartment,
                AdressId = librarian.AdressId
            };
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

