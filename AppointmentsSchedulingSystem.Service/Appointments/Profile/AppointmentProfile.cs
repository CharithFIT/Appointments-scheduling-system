using AppointmentsSchedulingSystem.Repository.Models;
using AppointmentsSchedulingSystem.Service.Appointments.Convertors;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;

namespace AppointmentsSchedulingSystem.Repository.Appointments.Profile
{
    public class AppointmentProfile : AutoMapper.Profile
    {
        public AppointmentProfile()
        {
            CreateMap<AppointmentDto, Appointment>().ConvertUsing<AppointmentDtoToAppointmentConvertor>();
        }
    }
}
