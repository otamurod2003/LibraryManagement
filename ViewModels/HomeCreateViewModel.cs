using LibraryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.ViewModels
{
    public class HomeCreateViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string? FullName { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(20, 100)]
        public int Age { get; set; }
        public Departments LibraryDepartment { get; set; }

        //public IFormFile Photo { get; set; }

    }
}
