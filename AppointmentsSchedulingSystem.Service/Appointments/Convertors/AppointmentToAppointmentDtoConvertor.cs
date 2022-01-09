using AppointmentsSchedulingSystem.Repository.Models;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;
using AutoMapper;

namespace AppointmentsSchedulingSystem.Service.Appointments.Convertors
{
    public class AppointmentToAppointmentDtoConvertor : ITypeConverter<Appointment, AppointmentDto>
    {
        public AppointmentDto Convert(Appointment source, AppointmentDto destination, ResolutionContext context)
        {
            if (destination == null)
            {
                destination = new AppointmentDto();
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            destination.StartDate = DateTime.SpecifyKind(source.StartTime, DateTimeKind.Utc);
            destination.EndDate = DateTime.SpecifyKind(source.EndTime, DateTimeKind.Utc);
            destination.CreationDate = DateTime.SpecifyKind(source.CreationDate, DateTimeKind.Utc);
            destination.PersonName = source.Person.Name;
            destination.PhoneNumber = source.Person.PhoneNumber;
            destination.Email = source.Person.Email;

            return destination;

        }
    }
}
