using Microsoft.Extensions.DependencyInjection;

namespace AppointmentsSchedulingSystem.Repository.Appointments
{
    public static class AppointmentRepositoryInstaller
    {
        public static IServiceCollection InstallAppoinmentRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}
