using HealthCareScheduler.Models;

namespace HealthCareScheduler.Repositories.Interface
{
	public interface IMedicalRecordRepository
	{
		void CreateMedicalRecord(MedicalRecord medicalRecord);
		MedicalRecord GetMedicalRecordById(Guid id);
		MedicalRecord GetMedicalRecordByAppointmentId(Guid id);
		void UpdateMedicalRecord(MedicalRecord medicalRecord);
		void DeleteMedicalRecord(MedicalRecord medicalRecord);
	}
}
