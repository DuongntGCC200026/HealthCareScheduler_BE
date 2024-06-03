
using HealthCareScheduler.Dto.MedicalRecord;

namespace HealthCareScheduler.Services.Interface
{
	public interface IMedicalRecordService
	{
		MedicalRecordDto AddMedicalRecord(CreateMedicalRecordDto createMedicalRecordDto);
		MedicalRecordDto UpdateMedicalRecord(Guid id, UpdateMedicalRecordDto updateMedicalRecordDto);
		string DeleteMedicalRecord(Guid id);
		MedicalRecordDto GetMedicalRecordById(Guid id);
		MedicalRecordDto GetMedicalRecordByAppointmentId(Guid id);
	}
}
