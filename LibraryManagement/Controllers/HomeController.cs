using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericCRUDService<LibrarianModel> _librarianSvc;
        public HomeController(IGenericCRUDService<LibrarianModel> librarianSvc)
        {
            _librarianSvc = librarianSvc;
        }
        public async Task<IActionResult> Index()
        {
            var librarians = await Task.FromResult(_librarianSvc.GetAll());
            return View(await librarians);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var librarian = await Task.FromResult(_librarianSvc.Get(id));
            return View(await librarian);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }
        public async Task<IActionResult> Create(LibrarianModel librarian)
        {
            if (ModelState.IsValid)
            {
                LibrarianModel newLibrarian = new LibrarianModel
                {
                    FullName = librarian.FullName,
                    Age = librarian.Age,
                    LibraryDepartment = librarian.LibraryDepartment,
                };
                await _librarianSvc.Create(newLibrarian);
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var existlibrarian = await _librarianSvc.Get(id);
            return View(existlibrarian);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LibrarianModel librarian)
        {
            if (ModelState.IsValid)
            {
                LibrarianModel newLibrarian = new LibrarianModel
                {
                    FullName = librarian.FullName,
                    Age = librarian.Age,
                    LibraryDepartment = librarian.LibraryDepartment,
                };
                await _librarianSvc.Update(newLibrarian);
                return RedirectToAction("index");
              
            }
            return View();
        }

        [HttpGet, HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var librarian = await _librarianSvc.Get(id);
            if (librarian != null)
            {
                await _librarianSvc.Delete(librarian.Id);
            }
            return RedirectToAction("index");
        }

        #region UploadFileModelValidate_BusinessLogic
  /* public bool FileUploadRules(IFormFile uploadFile)
         {
             if (uploadFile is not null && uploadFile.Length > 0)
             {
                 if (uploadFile.ContentType != "image/jpeg" && uploadFile.ContentType != "image/png")
                 {
                     return false;
                 }
                 if (uploadFile.Length > 3 * 1024 * 1024) 
                 {
                     return false;
                 }

                 return true;

             }
             return false;
         }*/
        #endregion
      
    }
}
