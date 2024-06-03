using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthCareScheduler.Repositories
{
	public class MedicalRecordRepository : IMedicalRecordRepository
	{
		private readonly ApplicationDbContext _context;

		public MedicalRecordRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public void CreateMedicalRecord(MedicalRecord medicalRecord)
		{
			try
			{
				_context.MedicalRecords.Add(medicalRecord);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error creating Medical Record");
			}
		}

		public void DeleteMedicalRecord(MedicalRecord medicalRecord)
		{
			try
			{
				_context.MedicalRecords.Remove(medicalRecord);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error deleting Medical Record");
			}
		}

		public MedicalRecord GetMedicalRecordById(Guid id)
		{
			try
			{
				return _context.MedicalRecords
					.Where(u => u.RecordId == id)
					.AsNoTracking().FirstOrDefault();
			}
			catch (Exception)
			{
				throw new Exception("Error getting Medical Record");
			}
		}

		public MedicalRecord GetMedicalRecordByAppointmentId(Guid id)
		{
			try
			{
				return _context.MedicalRecords
					.Where(u => u.AppointmentId == id)
					.AsNoTracking()
					.FirstOrDefault();
			}
			catch (Exception)
			{
				throw new Exception("Error getting Medical Record");
			}
		}

		public void UpdateMedicalRecord(MedicalRecord medicalRecord)
		{
			try
			{
				_context.Entry<MedicalRecord>(medicalRecord).State = EntityState.Modified;
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error Medical Record");
			}
		}
	}
}
