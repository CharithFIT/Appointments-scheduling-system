using AppointmentsSchedulingSystem.Service.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentsSchedulingSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        [HttpPost]
        public string Post([FromBody] AppointmentDto appointmentDto)
        {
            return "Test me";
        }
    }
}
