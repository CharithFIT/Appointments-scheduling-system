using AppointmentsSchedulingSystem.Service.Appointments;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(200, null, typeof(AppointmentDto))]
        public async Task<IActionResult> PostAsync([FromBody] AppointmentCreationDto appointmentDto, CancellationToken cancellationToken = default)
        {
            AppointmentDto result =  await this.appointmentService.InsertAppointmentAsync(appointmentDto, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(200, null, typeof(List<AppointmentDto>))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken = default)
        {
            List<AppointmentDto> appointments = await this.appointmentService.GetAppointmentsAsync(cancellationToken);

            return Ok(appointments);
        }
    }
}
