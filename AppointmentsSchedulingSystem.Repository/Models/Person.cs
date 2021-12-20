using System.ComponentModel.DataAnnotations;

namespace AppointmentsSchedulingSystem.Repository.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
                
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
