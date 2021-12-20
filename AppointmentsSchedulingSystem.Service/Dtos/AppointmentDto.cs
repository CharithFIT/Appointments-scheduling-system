﻿namespace AppointmentsSchedulingSystem.Service.Dtos
{
    public  class AppointmentDto
    {
        public string PersonName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
                
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
