using HealthCareScheduler.Dto.User;

namespace HealthCareScheduler.Services.Interface
{
	public interface IUserService
	{
		UserDto GetUserById(Guid userId);
		//UserDto UpdateProfile(Guid id, UpdateUserDto updateUserDto);
		UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto);
		string DeleteUser(Guid userId);
		UserDto CreateUser(CreateUserDto userDto);
		List<UserDto> GetAllUser();
		List<RoleDto> GetAllRole();
		List<UserDto> GetAllUserByRoleIdAndBranchId(QueryDto queryDto);
		string ChangePassword(Guid userId, ChangePasswordDto changePasswordDto);
	}
}
