
namespace HealthCareScheduler.Dto.MedicalRecord
{
	public class UpdateMedicalRecordDto : CreateMedicalRecordDto
	{
		public Guid RecordId { get; set; }
	}
}
