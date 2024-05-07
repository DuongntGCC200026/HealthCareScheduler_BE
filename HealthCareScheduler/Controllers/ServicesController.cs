using HealthCareScheduler.Dto.Service;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareScheduler.Controllers
{
	[Route("api/service")]
	[ApiController]
	public class ServicesController : ControllerBase
	{
		private readonly IServiceService _serviceService;

		public ServicesController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		[HttpPost]
		public IActionResult AddService([FromBody] CreateServiceDto serviceDto)
		{
			try
			{
				ServiceDto createdService = _serviceService.AddService(serviceDto);
				return Ok(createdService);
			}
			catch (ConflictException ex)
			{
				return Conflict(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteService(Guid id)
		{
			try
			{
				string message = _serviceService.DeleteService(id);
				return Ok(message);
			}
			catch (NotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet]
		public IActionResult GetAllService([FromQuery] int limit = 0)
		{
			try
			{
				List<ServiceDto> services = _serviceService.GetAllService(limit);
				return Ok(services);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetServiceById(Guid id)
		{
			try
			{
				ServiceDto service = _serviceService.GetServiceById(id);
				return Ok(service);
			}
			catch (NotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("{id}")]
		public IActionResult UpdateService(Guid id, [FromBody] UpdateServiceDto serviceDto)
		{
			try
			{
				ServiceDto updatedService = _serviceService.UpdateService(id, serviceDto);
				return Ok(updatedService);
			}
			catch (NotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
	}
}
