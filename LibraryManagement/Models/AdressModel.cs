using LibraryManagement.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AdressModel
    {
        public int Id { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }

      
    }
}
