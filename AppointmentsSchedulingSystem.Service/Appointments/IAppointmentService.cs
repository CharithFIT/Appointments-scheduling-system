using AppointmentsSchedulingSystem.Service.Appointments.Dtos;

namespace AppointmentsSchedulingSystem.Service.Appointments
{
    public interface IAppointmentService
    {
        Task InsertAppointmentAsync(AppointmentDto appointment, CancellationToken cancellationToken = default);
    }
}
