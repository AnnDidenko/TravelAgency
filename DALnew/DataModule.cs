using DALnew.Context;
using DALnew.Interfaces;
using DALnew.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace DALnew
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connection = config.GetConnectionString("Develop");

            services.AddDbContext<OrderContext>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
