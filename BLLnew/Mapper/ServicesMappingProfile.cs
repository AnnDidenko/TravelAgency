using AutoMapper;
using BLLnew.DTO;
using DALnew.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Mapper
{
    public class ServicesMappingProfile: Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<RegistrationRequestDTO, User>()
                .ForMember(x => x.Role, opt => opt.MapFrom(y => "User"));

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<TourDTO, Tour>();
            CreateMap<Tour, TourDTO>();

            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
