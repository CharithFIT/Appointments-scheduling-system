using System.ComponentModel.DataAnnotations;

namespace AppointmentsSchedulingSystem.Service.Appointments.Dtos
{
    public record AppointmentCreationDto(
          [Required] string PersonName
         ,[Required]  string Email
         ,[Required]  string PhoneNumber
         ,[Required]  DateTime StartDate
         ,[Required]  DateTime EndDate);
}
