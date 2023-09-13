using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace PHONES_MARKETE.Models
{
    public class UserModel 
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }


        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }






    }
}
