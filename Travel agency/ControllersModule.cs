using AutoMapper;
using BLLnew;
using BLLnew.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_agency.Mapper;

namespace Travel_agency
{
    public static class ControllersModule
    {
        public static void Register(IServiceCollection services)
        {
            ServicesModule.Register(services);
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ServicesMappingProfile());
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
           
            
            
        }
    }
}
