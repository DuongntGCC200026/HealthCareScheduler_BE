using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Models
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid UserId { get; set; }

		[StringLength(255)]
		public string Email { get; set; }

		public string Password { get; set; }

		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		public DateTime DateOfBirth { get; set; }

		[StringLength(10)]
		public string PhoneNumber { get; set; }

		[StringLength(100)]
		public string Address { get; set; }

		public string? Specialization { get; set; }
		public Guid RoleId { get; set; }
		public Guid? BranchId { get; set; }

		[ForeignKey("RoleId")]
		public virtual Role? Role { get; set; }

		[ForeignKey("BranchId")]
		public virtual Branch? Branch { get; set; }

		public virtual ICollection<Feedback>? Contributions { get; set; }

		public virtual ICollection<Appointment>? PatientApppointments { get; set; }

		public virtual ICollection<Appointment>? DoctorApppointments { get; set; }

	}
}
