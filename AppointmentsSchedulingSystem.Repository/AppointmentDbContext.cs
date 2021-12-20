using AppointmentsSchedulingSystem.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentsSchedulingSystem.Repository
{
    public  class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
