using BLLnew.DTO;
using DALnew.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Interfaces
{
    public interface IAuthService
    {
        bool DoesUserNameExist(string userName);
        TokenResponseDTO Register(RegistrationRequestDTO data);
        TokenResponseDTO Authenticate(RegistrationRequestDTO data);
        List<UserDTO> AllUsers();
    }
}
