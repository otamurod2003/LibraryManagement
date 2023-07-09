using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using LibraryManagement.DataAccess;
using LibraryManagement.Services;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenericCRUDService<LibrarianModel> _librarianSvc;
        private readonly IWebHostEnvironment _webhost;

        public HomeController(IGenericCRUDService<LibrarianModel> librarianSvc, IWebHostEnvironment webhost)
        {
            _librarianSvc = librarianSvc;
            _webhost = webhost;
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



        [HttpPost]
        public async Task<IActionResult> Create(LibrarianModel librarian)
        {
            if (ModelState.IsValid)
            {
                /*  string uploadFolder = Path.Combine(_webhost.WebRootPath, "images");
                  uniqueFileName = Guid.NewGuid().ToString() + "_" + librarian.Photo.FileName;

                  string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                  librarian.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
              }*/
                LibrarianModel newLibrarian = new LibrarianModel
                {
                    FullName = librarian.FullName,
                    Age = librarian.Age,
                    LibraryDepartment = librarian.LibraryDepartment,
                    // PhotoFilePath = uniqueFileName
                };
                await _librarianSvc.Create(newLibrarian);
                return RedirectToAction("index");
            }
            return View();
            /*ModelState.AddModelError(librarian.Photo.ContentType,"This image isn't  compatible...");
           return View();
       }*/


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
                /*if (FileUploadRules(librarian.Photo))
                {
                    string uniqueFileName = string.Empty;
                    if (librarian.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_webhost.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + librarian.Photo.FileName;

                        string imageFilePath = Path.Combine(uploadFolder, uniqueFileName);
                        librarian.Photo.CopyTo(new FileStream(imageFilePath, FileMode.Create));
                    }*/
                LibrarianModel newLibrarian = new LibrarianModel
                {
                    FullName = librarian.FullName,
                    Age = librarian.Age,
                    LibraryDepartment = librarian.LibraryDepartment,
                    //PhotoFilePath = uniqueFileName
                };
                /*newLibrarian =*/
                await _librarianSvc.Update(newLibrarian);
                return RedirectToAction("index");
                /*}
                ModelState.AddModelError(librarian.Photo.ContentType, "This image isn't  compatible...");
                return View();*/
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

        public bool FileUploadRules(IFormFile uploadFile)
        {
            if (uploadFile is not null && uploadFile.Length > 0)
            {
                //Rasm turi faqat jpeg va png formatlarni qabul qiladi
                if (uploadFile.ContentType != "image/jpeg" && uploadFile.ContentType != "image/png")
                {
                    return false;
                }
                if (uploadFile.Length > 3 * 1024 * 1024) // rasm hajmi 3 MB dan kam bo'lishi kerak
                {
                    return false;
                }

                return true;

            }
            return false;
        }
    }
}
