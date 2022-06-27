using Microsoft.EntityFrameworkCore;
using ProductShoppingWebsite.Server.Infrastructure.Persistence;
using ProductShoppingWebsite.Server.Infrastructure.Repositories;
using ProductShoppingWebsite.Server.Infrastructure.Services;
using ProductShoppingWebsite.Server.Interfaces;
using ProductShoppingWebsite.Shared;
using ProductShoppingWebsite.Shared.Dtos;

namespace ProductShoppingWebsite.Server.Infrastructure.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBannedSellerRepository, BannedSellerRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IBannedSellerService, BannedSellerService>();
            services.AddScoped<IReportService, ReportService>();

            services.AddAutoMapper(typeof(ConfigureServices));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
