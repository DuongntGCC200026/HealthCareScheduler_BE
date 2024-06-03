using HealthCareScheduler.Constraints;
using HealthCareScheduler.Dto.Appointment;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HealthCareScheduler.Repositories
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly ApplicationDbContext _context;

		public AppointmentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateAppointment(Appointment appointment)
		{
			try
			{
				_context.Appointments.Add(appointment);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error creating Appointment");
			}
		}

		public void DeleteAppointment(Appointment Appointment)
		{
			try
			{
				_context.Appointments.Remove(Appointment);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error deleting Appointment");
			}
		}

		public List<Appointment> GetAllAppointmentByBranchIdOrPatientIdorDoctorId(QueryDto queryDto)
		{
			try
			{
				var query = _context.Appointments
					.Include(a => a.Patient)
					.Include(b => b.Doctor)
					.Include(c => c.Service)
					.Include(d => d.Branch)
					.AsQueryable();

				List<Appointment> appointments = query.ToList();

				if (queryDto.BranchId.HasValue)
				{
					query = query.Where(u => u.BranchId == queryDto.BranchId);
				}
				if (queryDto.DoctorId.HasValue)
				{
					query = query.Where(u => u.DoctorId == queryDto.DoctorId);

				}
				if (queryDto.PatientId.HasValue)
				{
					query = query.Where(u => u.PatientId == queryDto.PatientId);

				}
				if (queryDto.AppointmentId.HasValue)
				{
					query = query.Where(u => u.AppointmentId == queryDto.AppointmentId);

				}
				if (queryDto.Status.HasValue)
				{
					if (queryDto.Status.Value.Equals(EStatus.Pending))
					{
						query = query.Where(u => u.Status == EStatus.Pending);
					}
					else if (queryDto.Status.Value.Equals(EStatus.Approved))
					{
						query = query.Where(u => u.Status == EStatus.Approved);
					}
					else if (queryDto.Status.Value.Equals(EStatus.Completed))
					{
						query = query.Where(u => u.Status == EStatus.Completed);
					}
					else
					{
						query = query.Where(u => u.Status == EStatus.Cancelled);
					}

				}
                if (queryDto.CreatedDate.HasValue)
                {
					query = query.Where(u => u.CreatedDate == queryDto.CreatedDate);
				}

				appointments = query.OrderByDescending(a => a.CreatedDate).ToList();

				return appointments;
			}
			catch (Exception)
			{
				throw new Exception("Error getting Appointment");
			}
		}

		public Appointment GetAppointmentById(Guid id)
		{
			return _context.Appointments
			.Include(a => a.Patient)
			.Include(a => a.Doctor)
			.Include(a => a.Service)
			.Include(a => a.Branch)
			.Include(a => a.MedicalRecords)
			.OrderByDescending(u => u.CreatedDate)
			.AsNoTracking()
			.FirstOrDefault(a => a.AppointmentId == id);
		}

		public void UpdateAppointment(Appointment appointment)
		{
			try
			{
				_context.Entry<Appointment>(appointment).State = EntityState.Modified;
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error updating Appointment");
			}
		}
	}
}
