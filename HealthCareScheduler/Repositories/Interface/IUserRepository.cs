using HealthCareScheduler.Dto.User;
using HealthCareScheduler.Models;

namespace HealthCareScheduler.Repositories.Interface
{
	public interface IUserRepository
	{
		void CreateUser(User user);
		User GetUserByEmail(string email);
		User GetUserById(Guid id);
		void UpdateUser(User user);
		void DeleteUser(User user);
		List<User> GetAllUser();
		List<User> GetAllUserByRoleIdAndBranchId(QueryDto queryDto);
	}
}
