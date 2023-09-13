using System.ComponentModel.DataAnnotations;

namespace PHONES_MARKETE.Areas.admin.Models
{
    public class VmEditUser
    {
        public VmEditUser()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }


        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }
    }
}
