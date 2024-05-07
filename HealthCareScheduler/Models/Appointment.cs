using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareScheduler.Models
{
	public class Appointment
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid AppointmentId { get; set; }
		public DateTime DateTime { get; set; }
		public string Noted {  get; set; }
		public string Status { get; set; }
		public Guid PatientId { get; set; }
		public Guid DoctorId { get; set; }
		public Guid ServiceId { get; set; }
		public Guid BranchId { get; set; }
		public virtual User? Patient { get; set; }
		public virtual User? Doctor { get; set; }
		[ForeignKey("ServiceId")]
		public virtual Service? Service { get; set; }
		[ForeignKey("BranchId")]
		public virtual Branch? Branch { get; set; }
		public virtual ICollection<MedicalRecord>? MedicalRecords { get; set; }
	}
}
