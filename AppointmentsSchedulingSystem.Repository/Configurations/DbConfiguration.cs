using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentsSchedulingSystem.Repository
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppointmentDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
