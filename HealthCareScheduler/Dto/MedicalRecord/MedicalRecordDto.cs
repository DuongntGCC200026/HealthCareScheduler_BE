namespace HealthCareScheduler.Dto.MedicalRecord
{
	public class MedicalRecordDto
	{
		public Guid RecordId { get; set; }
		public string Dianosis { get; set; }
		public string Treatment { get; set; }
		public string Note { get; set; }
		public string Prescription { get; set; }
		public Guid AppointmentId { get; set; }
	}
}
