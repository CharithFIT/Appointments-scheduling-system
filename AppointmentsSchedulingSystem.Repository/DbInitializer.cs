
namespace AppointmentsSchedulingSystem.Repository
{
    public class DbInitializer
    {
        public static void Initialize(AppointmentDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
