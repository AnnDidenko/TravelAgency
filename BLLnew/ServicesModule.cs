using AutoMapper;
using BLLnew.Interfaces;
using BLLnew.Mapper;
using BLLnew.Services;
using DALnew;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew
{
    public static class ServicesModule
    {
        public static void Register(IServiceCollection services)
        {
            DataModule.Register(services);

            services.AddScoped<PasswordHasher>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInfoTourService, InfoTourService>();
            services.AddScoped<IManageOrderService, ManageOrderService>();
            services.AddScoped<IManageTourService, ManageTourService>();
        }
    }
}
