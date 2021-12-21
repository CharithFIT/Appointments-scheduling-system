using AppointmentsSchedulingSystem.Repository.Models;

namespace AppointmentsSchedulingSystem.Repository.Appointments
{
    public interface IAppointmentRepository
    {
        Task InsertAppointmentAsync(Appointment appointment, CancellationToken cancellationToken = default);

        Task SaveAsyc(CancellationToken cancellationToken = default);

        bool HasAlreadyBookedAppointment(DateTime startDate, DateTime endDate);
    }
}
