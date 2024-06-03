using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Dto.MedicalRecord
{
	public class CreateMedicalRecordDto
	{
		[Required]
		public string Dianosis { get; set; }

		[Required]
		public string Treatment { get; set; }

		public string? Note { get; set; }

		[Required]
		public string Prescription { get; set; }

		[Required]
		public Guid AppointmentId { get; set; }
	}
}
