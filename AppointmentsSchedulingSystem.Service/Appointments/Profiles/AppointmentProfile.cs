using AppointmentsSchedulingSystem.Repository.Models;
using AppointmentsSchedulingSystem.Service.Appointments.Convertors;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;

namespace AppointmentsSchedulingSystem.Service.Appointments.Profiles
{
    public class AppointmentProfile : AutoMapper.Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentCreationDto, Appointment>().ConvertUsing<AppointmentDtoToAppointmentConvertor>();
            CreateMap<Appointment, AppointmentDto>().ConvertUsing<AppointmentToAppointmentDtoConvertor>();
        }
    }
}
