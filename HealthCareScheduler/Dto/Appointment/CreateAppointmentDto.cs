using HealthCareScheduler.Dto.User;
using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Dto.Appointment
{
	public class CreateAppointmentDto
	{
		[Required(ErrorMessage = "The Date and Time can not empty!")]
		public DateTime DateTime { get; set; }
		public string? Noted { get; set; }
		public string Status { get; set; }
		public DateTime CreatedDate { get; set; }
		public Guid PatientId { get; set; }
		public Guid? DoctorId { get; set; }
		public Guid ServiceId { get; set; }
		public Guid BranchId { get; set; }
		public UserDto? Patient { get; set; }
		public UserDto? Doctor { get; set; }
	}
}
