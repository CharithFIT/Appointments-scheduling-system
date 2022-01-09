using AppointmentsSchedulingSystem.Service.Appointments.Dtos;

namespace AppointmentsSchedulingSystem.Service.Appointments
{
    public interface IAppointmentService
    {
        Task InsertAppointmentAsync(AppointmentCreationDto appointment, CancellationToken cancellationToken = default(CancellationToken));


        Task<List<AppointmentDto>> GetAppointmentsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
