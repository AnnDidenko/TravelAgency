using AutoMapper;
using BLLnew.DTO;
using BLLnew.Exceptions;
using BLLnew.Interfaces;
using DALnew.Entities;
using DALnew.Interfaces;
using DALnew.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BLLnew.Services
{
    public class AuthService: IAuthService
    {
        private IUserRepository userRepository;
        private JWTHelper jwt;
        private IMapper mapper;
        private SymmetricSecurityKey key;
        private JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        private PasswordHasher hasher;

        public AuthService(IUserRepository userRepository, IOptionsMonitor<JWTHelper> jwt, PasswordHasher hasher, IMapper mapper)
        {
            this.mapper = mapper;
            this.jwt = jwt.CurrentValue;
            this.userRepository = userRepository;
            this.hasher = hasher;
            key = this.jwt.GetSecretKey();
        }

        public bool DoesUserNameExist(string userName)
        {
            var users = userRepository.GetAll().Where(i => i.Username == userName);
            if(users == null)
            {
                return true;
            }
            return false;
        }

        public List<UserDTO> AllUsers()
        {
            var users = userRepository.GetAll().ToList();
            var usersDTO = mapper.Map<List<UserDTO>>(users);
            return usersDTO;
        }

        public TokenResponseDTO Authenticate(RegistrationRequestDTO data)
        {
            var user = userRepository.GetAll()
                    .Where(i => i.Email == data.Email && hasher.Check(i.Password, data.Password))
                    .FirstOrDefault();

            if(user == null)
            {
                throw new InvalidAuthenticateException("Wrong login or password");
            }

            var tokenDescriptor = GetTokenDescriptor(user);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenResponseDTO { Token = tokenHandler.WriteToken(token) };
        }

        public TokenResponseDTO Register(RegistrationRequestDTO data)
        {
            var user = userRepository.GetAll()
                    .Where(i => i.Email == data.Email)
                    .FirstOrDefault();

            if(user != null)
            {
                throw new EntityAlreadyExistsException("User already exists");
            }

            var newUser = mapper.Map<User>(data);
            newUser.Role = "User";
            newUser.Password = hasher.Hash(data.Password);
            userRepository.Add(newUser);

            var tokenDescriptor = GetTokenDescriptor(newUser);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenResponseDTO { Token = tokenHandler.WriteToken(token) };
        }

        private SecurityTokenDescriptor GetTokenDescriptor(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                             new Claim[] {
                                new Claim (ClaimsIdentity.DefaultNameClaimType, user.Username),
                                new Claim (ClaimsIdentity.DefaultRoleClaimType, user.Role),
                             },
                             "Token",
                             ClaimsIdentity.DefaultNameClaimType,
                             ClaimsIdentity.DefaultRoleClaimType
                             ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
            };

            return tokenDescriptor;
        }
    }
}
