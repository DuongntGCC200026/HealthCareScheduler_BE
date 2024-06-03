namespace HealthCareScheduler.Dto.User
{
	public class QueryDto
	{
		public Guid? RoleId { get; set; }
		public Guid? BranchId { get; set; }
		public string? Email { get; set; }
	}
}
