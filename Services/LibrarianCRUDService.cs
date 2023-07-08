using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System.Security.AccessControl;

namespace LibraryManagement.Services
{
    public class LibrarianCRUDService : IGenericCRUDService<LibrarianModel>
    {
        private readonly ILibrarianRepository _librarianRepository;

        public LibrarianCRUDService(ILibrarianRepository librarianRepository)
        {
            _librarianRepository = librarianRepository;
        }
        public async Task<LibrarianModel> Create(LibrarianModel model)
        {
            var librarian = new Librarian
            {
                FullName = model.FullName,
                Age = model.Age,
                LibraryDepartment = (DataAccess.Departments)model.LibraryDepartment,
                PhotoFilePath = model.PhotoFilePath,
            };
            var createdLibrarian = await Task.FromResult(_librarianRepository.CreateLibrarian(librarian));
            var result = new LibrarianModel
            {
                FullName = createdLibrarian.FullName,
                Age = createdLibrarian.Age,
                PhotoFilePath = createdLibrarian.PhotoFilePath,
                LibraryDepartment = (Models.Departments)createdLibrarian.LibraryDepartment,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _librarianRepository.DeleteLibrarian(id);                    
        }

        public async Task<LibrarianModel> Get(int id)
        {
            var librarian = await _librarianRepository.GetLibrarian(id);
            var model = new LibrarianModel
            {
                //Id = librarian.Id,
                FullName = librarian.FullName,
                Age = librarian.Age,
                LibraryDepartment = (Models.Departments)librarian.LibraryDepartment,
                PhotoFilePath = librarian.PhotoFilePath,
            };
            return model;
        }

        public async Task<List<LibrarianModel>> GetAll()
        {
            var result = new List<LibrarianModel>();
            var librarians = await _librarianRepository.GetAllLibrarians();
            foreach(var librarian in librarians)
            {
                var model = new LibrarianModel  
                {
                    FullName = librarian.FullName,
                    Age = librarian.Age,
                    LibraryDepartment = (Models.Departments)librarian.LibraryDepartment,
                    PhotoFilePath = librarian.PhotoFilePath,
                    Id = librarian.Id
                };

                result.Add(model);
            }
            return result;
        }

        public async Task<LibrarianModel> Update(LibrarianModel model)
        {
            var librarian = new Librarian
            {
                FullName = model.FullName,
                Age = model.Age,
                PhotoFilePath = model.PhotoFilePath,
                LibraryDepartment = (DataAccess.Departments)model.LibraryDepartment,
            };
            var updatedLibrarian =await  _librarianRepository.UpdateLibrarian(librarian);
            var result = new LibrarianModel
            {
                FullName = updatedLibrarian.FullName,
                Age = updatedLibrarian.Age,
                LibraryDepartment = (Models.Departments)updatedLibrarian.LibraryDepartment,
                PhotoFilePath = updatedLibrarian.PhotoFilePath,
            };

            return result;
        }

        
    }
}

