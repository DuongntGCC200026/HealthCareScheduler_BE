namespace HealthCareScheduler.Dto.Appointment
{
	public class UpdateAppointmentDto : CreateAppointmentDto
	{
		public Guid AppointmentId { get; set; }
	}
}
