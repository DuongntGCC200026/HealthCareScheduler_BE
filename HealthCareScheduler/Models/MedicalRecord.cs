using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareScheduler.Models
{
	public class MedicalRecord
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid RecordId { get; set; }

		[StringLength(100)]
		public string Dianosis { get; set; }

		public string Treatment { get; set; }

		public string Note { get; set; }
		public string Prescription { get; set; }
		public Guid AppointmentId { get; set; }

		[ForeignKey("AppointmentId")]
		public virtual Appointment? Appointment { get; set; }
	}
}
