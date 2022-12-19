using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ControllPanel.Model
{

    public class UpdateAccountDTO: CreateAccountDTO
    {

    }
    public class AccountDTO : CreateAccountDTO
    {
        public int Id { get; set; }
      public AddressDTO Addresses { get; set;  }
    }

    public class CreateAccountDTO
    {

        [Required(ErrorMessage = "The Personal Id is required")]
        public long PersonalId { get; set; }//Should be required and it should be exactly 11 characters.

       [Required(ErrorMessage = "The First Name is required")]
       [StringLength(maximumLength: 5, ErrorMessage = " The First Name is too long")]
        public string FirstName { get; set; }//Should be required and less than 60 characters


        [Required(ErrorMessage = "The Last Name is required")]
        public string LastName { get; set; }//Should be required and less than 60 characters


        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }//Should be required and email format.

        //[DataType(DataType.PhoneNumber)]
        public long MobileNumber { get; set; }//Should be correct format with country code********

        [Required(ErrorMessage = "The Sex is required")]
        //[Display(Name = "Sex")]
        public bool IsFemale { get; set; }//Should be required
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }

        //[DataType(DataType.ImageUrl)]
        public string ProfilePhotopath { get; set; }

        [Required(ErrorMessage = "The Adderss Id  is required")]
        public int AddressId { get; set; }


    }




}
