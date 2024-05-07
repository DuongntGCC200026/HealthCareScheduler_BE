using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;

namespace HealthCareScheduler.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private readonly ApplicationDbContext _context;

		public RoleRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public Role GetRoleById(Guid id)
		{
			try
			{
				return _context.Roles.FirstOrDefault(r => r.RoleId == id);
			}
			catch (Exception)
			{
				throw new Exception("Error getting role");
			}
		}

		public Role GetRoleByName(string name)
		{
			try
			{
				return _context.Roles.FirstOrDefault(r => r.Name == name);
			}
			catch (Exception)
			{
				throw new Exception("Error getting role");
			}
		}

		public List<Role> GetRoles()
		{
			try
			{
				return _context.Roles
					.Where(r => r.Name != "Administrator")
					.ToList();
			}
			catch (Exception)
			{
				throw new Exception("Error getting roles");
			}
		}
	}
}
