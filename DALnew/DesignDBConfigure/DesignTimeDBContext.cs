using DALnew.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DALnew.DesignDBConfigure
{
    public class DesignTimeDBContext : IDesignTimeDbContextFactory<OrderContext>
    {
        public OrderContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<OrderContext>();

            var connectionString = configuration.GetConnectionString("Develop");
            //var connectionString = configuration.GetConnectionString("Realese");

            builder.UseSqlServer(connectionString);

            return new OrderContext(builder.Options);
        }
    }
}
