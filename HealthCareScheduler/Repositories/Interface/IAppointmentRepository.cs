using HealthCareScheduler.Dto.Appointment;
using HealthCareScheduler.Models;

namespace HealthCareScheduler.Repositories.Interface
{
	public interface IAppointmentRepository
	{
		void CreateAppointment(Appointment Appointment);
		Appointment GetAppointmentById(Guid id);
		void UpdateAppointment(Appointment Appointment);
		void DeleteAppointment(Appointment Appointment);
		List<Appointment> GetAllAppointmentByBranchIdOrPatientIdorDoctorId(QueryDto queryDto);
	}
}
