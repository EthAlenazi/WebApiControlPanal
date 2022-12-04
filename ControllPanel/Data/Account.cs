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
        public long PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long MobileNumber { get; set; }
        public bool IsFemale { get; set; } //where  0 = Male|| 1 = Female
        public bool IsAdmin { get; set; }//where 0 = user || 1 = Admin
        public bool IsActive { get; set; }//where 0= Active || 1 = InActive 
        public string ProfilePhotopath { get; set; }


        [ForeignKey(nameof(Address))]
          public int AddressId { get; set; }   
        public Address Addresses { get; set; }




    }
}


 

 
 


