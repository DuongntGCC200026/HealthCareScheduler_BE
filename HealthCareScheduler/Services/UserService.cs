using AutoMapper;
using HealthCareScheduler.Dto.User;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using HealthCareScheduler.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace HealthCareScheduler.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository=userRepository;
			_mapper=mapper;
		}

		public UserDto CreateUser(CreateUserDto userDto)
		{
			// Get user by email
			User user = _userRepository.GetUserByEmail(userDto.Email);
			if (user != null)
			{
				throw new ConflictException("Email already exists");
			}

			// Hash password
			var passwordHasher = new PasswordHasher<string>();
			userDto.Password = passwordHasher.HashPassword(null, userDto.Password);

			// Map registerDto to user
			user = _mapper.Map<User>(userDto);

			// Create user
			_userRepository.CreateUser(user);

			return _mapper.Map<UserDto>(_userRepository.GetUserById(user.UserId));
		}

		public string DeleteUser(Guid userId)
		{
            User user = _userRepository.GetUserById(userId) ?? throw new NotFoundException("User not found");
			_userRepository.DeleteUser(user);

			return "User deleted successfully";
		}

		public List<UserDto> GetAllUser()
		{
			List<User> users = _userRepository.GetAllUser();
			return _mapper.Map<List<UserDto>>(users);
		}

		public List<UserDto> GetAllUserByRoleIdAndBranchId(QueryDto queryDto)
		{
			List<User> users = _userRepository.GetAllUserByRoleIdAndBranchId(queryDto);
			return _mapper.Map<List<UserDto>>(users);
		}

		public UserDto GetUserById(Guid userId)
		{
			User user = _userRepository.GetUserById(userId) ?? throw new NotFoundException("User not found");
			return _mapper.Map<UserDto>(user);
		}

		public UserDto UpdateUser(Guid id, UpdateUserDto updateUserDto)
		{
			User user = _userRepository.GetUserById(id) ?? throw new NotFoundException("User not found");
			
			//updateUserDto.Password ??= user.Password;
			//updateUserDto.RoleId ??= user.RoleId;


			if (updateUserDto.Password != null)
			{
				updateUserDto.Password = HashPassword(updateUserDto.Password);
			}
			else
			{
				updateUserDto.Password = user.Password;
			}
			user = _mapper.Map<User>(updateUserDto);
			_userRepository.UpdateUser(user);

			return _mapper.Map<UserDto>(_userRepository.GetUserById(user.UserId));
		}

		public bool VerifyPassword(string currentPassword, string oldPassword)
		{
			var passwordHasher = new PasswordHasher<string>();
			if (passwordHasher.VerifyHashedPassword(null, currentPassword, oldPassword) == PasswordVerificationResult.Failed)
			{
				return false;
			}
			return true;
		}

		public string HashPassword(string newPassword)
		{
			var passwordHasher = new PasswordHasher<string>();
			return passwordHasher.HashPassword(null, newPassword);
		}
	}
}
