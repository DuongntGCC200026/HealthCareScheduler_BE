using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Models;

namespace HealthCareScheduler.Dto.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
		public RoleDto? Role { get; set; }
        public BranchDto? Branch { get; set; }
    }
}
