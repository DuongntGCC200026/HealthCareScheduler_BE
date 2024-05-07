using HealthCareScheduler.Dto.User;

namespace HealthCareScheduler.Services.Interface
{
	public interface IRoleService
	{
		RoleDto GetRoleByName(string name);
		RoleDto GetRoleById(Guid id);
		List<RoleDto> GetRoles();

	}
}
