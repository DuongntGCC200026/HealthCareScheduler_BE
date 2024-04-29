using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Models
{
	public class Branch
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid BranchId { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(10)]
		public string PhoneNumber { get; set; }

		[StringLength(100)]
		public string Location { get; set; }
		public virtual ICollection<User>? Users { get; set; }
	}
}
