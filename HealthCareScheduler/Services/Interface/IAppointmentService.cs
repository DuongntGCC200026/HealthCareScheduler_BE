using HealthCareScheduler.Dto.Appointment;
using HealthCareScheduler.Models;

namespace HealthCareScheduler.Services.Interface
{
	public interface IAppointmentService
	{
		AppointmentDto CreateAppointment(CreateAppointmentDto createAppointmentDto);
		AppointmentDto GetAppointmentById(Guid id);
		AppointmentDto UpdateAppointment(Guid id, UpdateAppointmentDto appointment);
		string DeleteAppointment(Guid id);
		List<AppointmentDto> GetAllAppointmentByBranchIdOrPatientIdorDoctorId(QueryDto queryDto);
	}
}
