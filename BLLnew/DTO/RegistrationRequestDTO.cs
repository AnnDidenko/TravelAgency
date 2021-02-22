using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.DTO
{
    public class RegistrationRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
