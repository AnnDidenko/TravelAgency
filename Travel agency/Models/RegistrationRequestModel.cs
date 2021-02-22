using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_agency.Models
{
    public class RegistrationRequestModel
    {
        [Required]
        //[Remote("DoesUserNameExist", "AuthController", ErrorMessage = "Username already exists")]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email address is invalid")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string PasswordConfirm { get; set; }
        [Required]
        [RegularExpression(@"^[+][3][8]\d{10}$")]
        public string PhoneNumber { get; set; }
    }
}
