using HealthCareScheduler.Dto;
using HealthCareScheduler.Dto.Appointment;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Services;
using HealthCareScheduler.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareScheduler.Controllers
{
	[Route("api/appointment")]
	[ApiController]
	public class AppointmentsController : ControllerBase
	{
		private readonly IAppointmentService _appointmentService;

		public AppointmentsController(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			ResponseDto response = new();
			try
			{
				AppointmentDto user = _appointmentService.GetAppointmentById(id);
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

		[HttpGet("manageAppointment")]
		public IActionResult GetAllAppointmentByBranchIdOrPatientIdorDoctorId([FromQuery] QueryDto queryDto)
		{
			ResponseDto response = new();
			try
			{
				List<AppointmentDto> user = _appointmentService.GetAllAppointmentByBranchIdOrPatientIdorDoctorId(queryDto);
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
		public IActionResult Create([FromForm] CreateAppointmentDto createAppointmentDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ResponseDto response = new();
			try
			{
				AppointmentDto appointment = _appointmentService.CreateAppointment(createAppointmentDto);
				return Ok(appointment);
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
		public IActionResult Put(Guid id, [FromBody] UpdateAppointmentDto updateAppointmentDto)
		{
			ResponseDto response = new();
			try
			{
				AppointmentDto user = _appointmentService.UpdateAppointment(id, updateAppointmentDto);
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
				response.Message = _appointmentService.DeleteAppointment(id);
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
	}
}
