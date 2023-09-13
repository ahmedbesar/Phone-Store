using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class MyApplicationUser:ApplicationUser
    {
       
        public string City { get; set; }
        [NotMapped]
        public string? UserRoles { get; set; }


    }
}
