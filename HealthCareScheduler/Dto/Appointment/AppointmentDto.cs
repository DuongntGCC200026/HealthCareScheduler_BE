using HealthCareScheduler.Dto.User;
using HealthCareScheduler.Models;

namespace HealthCareScheduler.Dto.Appointment
{
	public class AppointmentDto
	{
		public Guid AppointmentId { get; set; }
		public DateTime DateTime { get; set; }
		public string Noted { get; set; }
		public string Status { get; set; }
		public Guid PatientId { get; set; }
		public Guid DoctorId { get; set; }
		public Guid ServiceId { get; set; }
		public Guid BranchId { get; set; }
		public UserDto? Patient { get; set; }
		public UserDto? Doctor { get; set; }
	}
}
