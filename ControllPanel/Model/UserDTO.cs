using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Model
{

    public class LoginDTO
    {
        [Required]
        [StringLength(15, ErrorMessage = ("Thie is Required"))]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



    }
    public class UserDTO: LoginDTO
    {
        public  string FirstName { get; set; }
        public  string LastName { get; set; }
        public ICollection<string> Roles { get; set; }

    }
}
