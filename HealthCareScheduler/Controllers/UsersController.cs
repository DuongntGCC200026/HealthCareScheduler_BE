using HealthCareScheduler.Dto.User;
using HealthCareScheduler.Dto;
using HealthCareScheduler.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthCareScheduler.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace HealthCareScheduler.Controllers
{
	[Authorize]
	[Route("api/user")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			ResponseDto response = new();
			try
			{
				List<UserDto> users = _userService.GetAllUser();
				return Ok(users);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpGet("roles")]
		public IActionResult GetRoles()
		{
			ResponseDto response = new();
			try
			{
				List<RoleDto> users = _userService.GetAllRole();
				return Ok(users);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			ResponseDto response = new();
			try
			{
				UserDto user = _userService.GetUserById(id);
				return Ok(user);
			}
			catch (NotFoundException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status404NotFound, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpGet("manageUser")]
		public IActionResult GetUserByRoleAndBranch([FromQuery] QueryDto queryDto)
		{
			ResponseDto response = new();
			try
			{
				List<UserDto> user = _userService.GetAllUserByRoleIdAndBranchId(queryDto);
				return Ok(user);
			}
			catch (NotFoundException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status404NotFound, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpPost]
		public IActionResult Create([FromBody] CreateUserDto createUserDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ResponseDto response = new();
			try
			{
				UserDto user = _userService.CreateUser(createUserDto);
				return Ok(user);
			}
			catch (ConflictException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status409Conflict, response);
			}
			catch (InvalidException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status400BadRequest, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpPut("{id}")]
		public IActionResult Put(Guid id, [FromBody] UpdateUserDto updateUserDto)
		{
			ResponseDto response = new();
			try
			{
				UserDto user = _userService.UpdateUser(id, updateUserDto);
				return Ok(user);
			}
			catch (NotFoundException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status404NotFound, response);
			}
			catch (InvalidException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status400BadRequest, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			ResponseDto response = new();
			try
			{
				response.Message = _userService.DeleteUser(id);
				return Ok(response);
			}
			catch (NotFoundException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status404NotFound, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpPut("{id}/change-password")]
		public IActionResult ChangePassword(Guid id, [FromBody] ChangePasswordDto changePasswordDto)
		{
			ResponseDto response = new();
			try
			{
				response.Message = _userService.ChangePassword(id, changePasswordDto);
				return Ok(response);
			}
			catch (NotFoundException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status404NotFound, response);
			}
			catch (InvalidException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status400BadRequest, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}
	}
}
