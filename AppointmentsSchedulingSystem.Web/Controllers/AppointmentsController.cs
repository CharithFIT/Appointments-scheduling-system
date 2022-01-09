using AppointmentsSchedulingSystem.Service.Appointments;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentsSchedulingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AppointmentDto appointmentDto, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.appointmentService.InsertAppointmentAsync(appointmentDto, cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<AppointmentDto> appointments = await this.appointmentService.GetAppointmentsAsync(cancellationToken);

            return Ok(appointments);
        }
    }
}
