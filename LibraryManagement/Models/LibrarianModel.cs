using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LibrarianModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Full Name")]
        public string FullName  { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(20,100)]
        public int  Age { get; set; }
        public Departments LibraryDepartment { get; set; }
        public int AdressId { get; set; }

        //public string PhotoFilePath { get; set; }
    }
}
