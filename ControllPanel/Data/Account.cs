using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Data
{
    public class Account
    {
        public int Id { get; set; }
        public int PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public bool Gender { get; set; } //where  1 = Male|| 0 = Female
        public bool IsAdmin { get; set; }//where 0 = user || 1 = Admin
        public string ProfilePhotopath { get; set; }
       
        [ForeignKey(nameof(Address))]
          public int AddressId { get; set; }   
        public Address Address { get; set; }




    }
}


 

 
 


