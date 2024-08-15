using SednaReservationAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder.Extensions;

namespace SednaReservationAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SednaReservationAPIDbContext>
    {
        public SednaReservationAPIDbContext CreateDbContext(string[] args)
        {
            // Get the current directory
            var basePath = Directory.GetCurrentDirectory();

            // Build the configuration
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // This is now the current directory
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("PostgreSQL");

            // Check if connection string is null or empty
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string 'PostgreSQL' is null or empty.");
            }

            // Build the DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<SednaReservationAPIDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            // Return the context
            return new SednaReservationAPIDbContext(optionsBuilder.Options);

            //DbContextOptionsBuilder<SednaReservationAPIDbContext> dbContextOptionsBuilder = new();
            //dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=sednacloud;Host=localhost;Port=5432;Database=SednaReservationAPIDb;");
            //return new(dbContextOptionsBuilder.Options);
        }
    }
}