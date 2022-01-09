using AppointmentsSchedulingSystem.Repository.Appointments;
using AppointmentsSchedulingSystem.Repository.Models;
using AppointmentsSchedulingSystem.Service.Appointments.Dtos;
using AutoMapper;

namespace AppointmentsSchedulingSystem.Service.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository ?? throw new ArgumentNullException(nameof(appointmentRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<AppointmentDto>> GetAppointmentsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Appointment> appointments = await this.appointmentRepository.GetAppintmentsAsync(cancellationToken);

            List<AppointmentDto> appointmentDtos = appointments.Select(a => this.mapper.Map<AppointmentDto>(a)).ToList();

            return appointmentDtos;
        }

        public async Task InsertAppointmentAsync(AppointmentCreationDto appointmentDto, CancellationToken cancellationToken = default)
        {
            if (appointmentDto == null)
            {
                throw new ArgumentNullException(nameof(appointmentDto));
            }

            bool bookableAppointment = !this.appointmentRepository.HasAlreadyBookedAppointment(appointmentDto.StartDate, appointmentDto.EndDate);

            if (bookableAppointment) 
            {
                throw new ApplicationException($"Already has an appoinment");
            }

            Appointment appointment = this.mapper.Map<Appointment>(appointmentDto);

            await this.appointmentRepository.InsertAppointmentAsync(appointment, cancellationToken);

            await this.appointmentRepository.SaveAsyc();
        }
    }
}
