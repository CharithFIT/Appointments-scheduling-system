using System.ComponentModel.DataAnnotations;

namespace AppointmentsSchedulingSystem.Repository.Models
{
    public  class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
