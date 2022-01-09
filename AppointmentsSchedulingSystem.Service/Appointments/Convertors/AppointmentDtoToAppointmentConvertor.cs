using AppointmentsSchedulingSystem.Repository.Models;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;
using AutoMapper;

namespace AppointmentsSchedulingSystem.Service.Appointments.Convertors
{
    public class AppointmentDtoToAppointmentConvertor : ITypeConverter<AppointmentCreationDto, Appointment>
    {
        public Appointment Convert(AppointmentCreationDto source, Appointment destination, ResolutionContext context)
        {
            if (destination == null) 
            {
                destination = new Appointment();
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            destination.StartTime = source.StartDate.ToUniversalTime();
            destination.EndTime = source.EndDate.ToUniversalTime();
            destination.CreationDate = DateTime.UtcNow;
            destination.Person = new Person
            {
                Name = source.PersonName,
                Email = source.Email,
                PhoneNumber = source.PhoneNumber,
            };

            return destination;
        }
    }
}
