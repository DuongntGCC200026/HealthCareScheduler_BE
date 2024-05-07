using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Dto.Branch
{
	public class BranchDto
	{
		public Guid BranchId { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[StringLength(10)]
		public string PhoneNumber { get; set; }

		[StringLength(100)]
		public string Location { get; set; }
	}
}
