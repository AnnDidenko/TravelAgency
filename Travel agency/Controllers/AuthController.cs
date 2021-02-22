using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLLnew.DTO;
using BLLnew.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Travel_agency.Models;

namespace Travel_agency.Controllers
{
    [Route("authorization")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }
        /*public bool DoesUserNameExist(string userName)
        {
            return authService.DoesUserNameExist(userName);
        }*/

        [HttpGet("users")]
        public IActionResult AllUsers()
        {
            authService.AllUsers();
            return Ok();
        }

        [HttpPost("registration")]
        public IActionResult Registration([FromBody] RegistrationRequestModel newUser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = mapper.Map<RegistrationRequestDTO>(newUser);
            authService.Register(user);
            return Ok();
        }

        [HttpPost("authenticate")]
        public Object Authenticate([FromBody] LoginRequestModel checkLogin)
        {
            var login = mapper.Map<RegistrationRequestDTO>(checkLogin);
            return authService.Authenticate(login);
            //return Ok();
        }
    }
}