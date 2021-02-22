using AutoMapper;
using BLLnew.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_agency.Models;

namespace Travel_agency.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationRequestModel, RegistrationRequestDTO>();
            CreateMap<LoginRequestModel, LoginRequestDTO>();
            CreateMap<LoginRequestModel, RegistrationRequestDTO>();
            CreateMap<CreateOrderRequestModel, OrderDTO>();
            CreateMap<CreateTourRequestModel, TourDTO>();
        }
       
    }
}
