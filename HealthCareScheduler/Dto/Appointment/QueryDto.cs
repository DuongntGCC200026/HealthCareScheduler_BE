using HealthCareScheduler.Constraints;

namespace HealthCareScheduler.Dto.Appointment
{
	public class QueryDto
	{
		public Guid? AppointmentId { get; set; }
		public Guid? BranchId { get; set; }
		public Guid? DoctorId { get; set; }
		public Guid? PatientId { get; set; }
		public EStatus? Status { get; set; }
	}
}
