using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILibrarianRepository _librarianRepository;

        public HomeController(ILibrarianRepository librarianRepository)
        {
            _librarianRepository = librarianRepository;
        }
        public async Task<IActionResult> Index()
        {
            var librarians = await Task.FromResult(_librarianRepository.GetAllLibrarians());
            return View(await librarians);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var librarian = await Task.FromResult(_librarianRepository.GetLibrarian(id));
            return View(await librarian);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Librarian librarian  = new Librarian();
            
            return await Task.FromResult(View(librarian));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Librarian librarian)
        {
            if(ModelState.IsValid)
            {
              var createdLibrarian =  await _librarianRepository.CreateLibrarian(librarian);
                return RedirectToAction("details", new { id = createdLibrarian.Id });
            }
           
               return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var existlibrarian = await _librarianRepository.GetLibrarian(id);
            return View(existlibrarian);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Librarian librarian)
        {
            if(ModelState.IsValid)
            {
                await _librarianRepository.UpdateLibrarian(librarian);
                return RedirectToAction("details", new {id=librarian.Id});  
            }
            return View();
        }

        [HttpGet, HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var librarian = await _librarianRepository.GetLibrarian(id);
            if(librarian !=null)
            {
               await _librarianRepository.DeleteLibrarian(librarian.Id);
            }

            return RedirectToAction("index");
        }
    }
}
