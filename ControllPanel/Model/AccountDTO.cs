using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControllPanel.Model
{
    public class AccountDTO : CreateAccountDTO
    {
        public int Id { get; set; }
      public AddressDTO Addresses { get; set;  }
    }

    public class CreateAccountDTO
    {

        [Required(ErrorMessage = "The Personal Id is required")]
        [MaxLength(11,ErrorMessage ="Phone number too long make suer 11 number")]
        [MinLength(11, ErrorMessage = "Phone number too short make suer 11 number")]
        public long PersonalId { get; set; }//Should be required and it should be exactly 11 characters.

        [Required(ErrorMessage = "The First Name is required")]
        [StringLength(maximumLength: 59, ErrorMessage = " The First Name is too long")]
        public string FirstName { get; set; }//Should be required and less than 60 characters


        [Required(ErrorMessage = "The Last Name is required")]
        [StringLength(maximumLength:59,ErrorMessage =" The Last Name is too long")]
        public string LastName { get; set; }//Should be required and less than 60 characters


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }//Should be required and email format.

        public long MobileNumber { get; set; }//Should be correct format with country code********

        [Required(ErrorMessage = "The Sex is required")]
        [Display(Name = "Sex")]
        public bool IsFemale { get; set; }//Should be required
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePhotopath { get; set; }

        [Required(ErrorMessage = "yhe Adderss Id  is required")]
        public int AddressId { get; set; }


    }


}
