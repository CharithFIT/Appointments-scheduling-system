using AppointmentsSchedulingSystem.Service.Appointments.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentsSchedulingSystem.Service.Appointments
{
    public static class AppointmentInstaller
    {
        public static IServiceCollection InstallAppoinmentServices(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentService, AppointmentService>();
            services.AddAutoMapper(typeof(AppointmentProfile));

            return services;
        }
    }
}
