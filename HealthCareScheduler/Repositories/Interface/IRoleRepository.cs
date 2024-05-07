using HealthCareScheduler.Models;

namespace HealthCareScheduler.Repositories.Interface
{
	public interface IRoleRepository
	{
		Role GetRoleByName(string name);
		Role GetRoleById(Guid id);
		List<Role> GetRoles();
	}
}
