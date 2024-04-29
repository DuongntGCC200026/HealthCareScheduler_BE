using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Models
{
	public class Feedback
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid FeedbackId { get; set; }

		[StringLength(255)]
		public string Content { get; set; }

		public DateTime Created { get; set; }

		public Boolean Status { get; set; }
		public Guid UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User? User { get; set; }

	}
}
