using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.Features.Commands.HotelExtensions.Create;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Application.Repositories.HotelExtensions;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Domain.Entities.Identity;
using SednaReservationAPI.Persistence.Contexts;
using SednaReservationAPI.Persistence.Repositories;
using SednaReservationAPI.Persistence.Repositories.HotelExtensions;
using SednaReservationAPI.Persistence.Repositories.RoomExtensions;
using SednaReservationAPI.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SednaReservationAPIDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<SednaReservationAPIDbContext>();

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IHotelReadRepository, HotelReadRepository>();
            services.AddScoped<IHotelWriteRepository, HotelWriteRepository>();
            services.AddScoped<IPaymentReadRepository, PaymentReadRepository>();
            services.AddScoped<IPaymentWriteRepository, PaymentWriteRepository>();
            services.AddScoped<IReservationReadRepository, ReservationReadRepository>();
            services.AddScoped<IReservationWriteRepository, ReservationWriteRepository>();
            services.AddScoped<IReviewReadRepository, ReviewReadRepository>();
            services.AddScoped<IReviewWriteRepository, ReviewWriteRepository>();
            services.AddScoped<IRoomReadRepository, RoomReadRepository>();
            services.AddScoped<IRoomWriteRepository, RoomWriteRepository>();
            services.AddScoped<IRoomTypeReadRepository, RoomTypeReadRepository>();
            services.AddScoped<IRoomTypeWriteRepository, RoomTypeWriteRepository>();
            services.AddScoped<IReadRepositoryRoomExtensions, RoomExtensionsReadRepository>();
            services.AddScoped<IWriteRepositoryRoomExtensions, RoomExtensionsWriteRepository>();
            services.AddScoped<IReadRepositoryHotelExtensions, HotelExtensionsReadRepository>();
            services.AddScoped<IWriteRepositoryHotelExtensions, HotelExtensionsWriteRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleServices, RoleServices>();
        }
    }
}
