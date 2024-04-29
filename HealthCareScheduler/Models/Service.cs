using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCareScheduler.Models
{
	public class Service
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ServiceId { get; set; }

		[StringLength(50)]
		public string ServiceName { get; set; }

		[StringLength(100)]
		public string ServiceDescription { get; set; }

		public virtual ICollection<Appointment>? Appointments { get; set; }
	}
}
