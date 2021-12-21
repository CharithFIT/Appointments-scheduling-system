using AppointmentsSchedulingSystem.Repository.Models;

namespace AppointmentsSchedulingSystem.Repository.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentDbContext dbContext;

        public AppointmentRepository(AppointmentDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public bool HasAlreadyBookedAppointment(DateTime startTime, DateTime endTime)
        {
            return this.dbContext.Appointments
                .Any(a => ((a.StartTime >= startTime && a.StartTime <= endTime) || (a.EndTime >= startTime && a.EndTime <= endTime))
                 || ((startTime >= a.StartTime && startTime < a.EndTime) || (endTime > a.StartTime && endTime <= a.EndTime)));
        }

        public async Task InsertAppointmentAsync(Appointment appointment, CancellationToken cancellationToken = default)
        {
            await this.dbContext.AddAsync(appointment, cancellationToken);
        }

        public async Task SaveAsyc(CancellationToken cancellationToken = default)
        {
            await this.dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
