using LibraryManagement.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.DataAccess
{
    public class Librarian
    {
        public int Id { get; set; }

        public string FullName  { get; set; }
       
        public int  Age { get; set; }
        public Departments LibraryDepartment { get; set; }

        //public string  PhotoFilePath { get; set; }
        public Adress Adress { get; set; }
        //public int AdressId { get; set; }
    }
}
