using AutoMapper;
using HealthCareScheduler.Dto.Appointment;
using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories;
using HealthCareScheduler.Repositories.Interface;
using HealthCareScheduler.Services.Interface;

namespace HealthCareScheduler.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepository;
		private readonly IMapper _mapper;

		public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
		{
			_appointmentRepository=appointmentRepository;
			_mapper=mapper;
		}
		public AppointmentDto CreateAppointment(CreateAppointmentDto createAppointmentDto)
		{
			Appointment appointment = _mapper.Map<Appointment>(createAppointmentDto);
			_appointmentRepository.CreateAppointment(appointment);

			return _mapper.Map<AppointmentDto>(appointment);
		}

		public string DeleteAppointment(Guid id)
		{
			Appointment appointment = _appointmentRepository.GetAppointmentById(id) ?? throw new NotFoundException("Appointment does not exist");
			_appointmentRepository.DeleteAppointment(appointment);

			return "Delete successful";
		}

		public List<AppointmentDto> GetAllAppointmentByBranchIdOrPatientIdorDoctorId(QueryDto queryDto)
		{
			List<Appointment> appointments = _appointmentRepository.GetAllAppointmentByBranchIdOrPatientIdorDoctorId(queryDto);
			return _mapper.Map<List<AppointmentDto>>(appointments);
		}

		public AppointmentDto GetAppointmentById(Guid id)
		{
			Appointment appointment = _appointmentRepository.GetAppointmentById(id) ?? throw new NotFoundException("Apppointment does not exists"); ;
			return _mapper.Map<AppointmentDto>(appointment);
		}

		public AppointmentDto UpdateAppointment(Guid id, UpdateAppointmentDto updateAppointmentDto)
		{
			_ = _appointmentRepository.GetAppointmentById(id) ?? throw new NotFoundException("Apppointment does not exist");
			updateAppointmentDto.AppointmentId = id;

			Appointment appointmentToUpdate = _mapper.Map<Appointment>(updateAppointmentDto);
			_appointmentRepository.UpdateAppointment(appointmentToUpdate);

			return _mapper.Map<AppointmentDto>(appointmentToUpdate);
		}
	}
}
