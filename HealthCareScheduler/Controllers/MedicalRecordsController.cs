using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Dto;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Services;
using HealthCareScheduler.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthCareScheduler.Dto.MedicalRecord;
using HealthCareScheduler.Dto.MedicalRecord;

namespace HealthCareScheduler.Controllers
{
	[Route("api/medicalRecord")]
	[ApiController]
	public class MedicalRecordsController : ControllerBase
	{
		private readonly IMedicalRecordService _medicalRecordService;

		public MedicalRecordsController(IMedicalRecordService medicalRecordService)
		{
			_medicalRecordService = medicalRecordService;
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			ResponseDto response = new ResponseDto();
			try
			{
				MedicalRecordDto medicalRecordDto = _medicalRecordService.GetMedicalRecordById(id);
				return Ok(medicalRecordDto);
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

		[HttpGet("viewMedicalRecord/{id}")]
		public IActionResult GetMedicalRecordByAppointmentId(Guid id)
		{
			ResponseDto response = new ResponseDto();
			try
			{
				MedicalRecordDto medicalRecordDto = _medicalRecordService.GetMedicalRecordByAppointmentId(id);
				return Ok(medicalRecordDto);
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
		public IActionResult Post([FromBody] CreateMedicalRecordDto createMedicalRecordDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ResponseDto response = new ResponseDto();
			try
			{
				MedicalRecordDto medicalRecordDto = _medicalRecordService.AddMedicalRecord(createMedicalRecordDto);
				return Ok(medicalRecordDto);
			}
			catch (ConflictException e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status409Conflict, response);
			}
			catch (Exception e)
			{
				response.Message = e.Message;
				return StatusCode(StatusCodes.Status500InternalServerError, response);
			}
		}

		[HttpPut("{id}")]
		public IActionResult Put(Guid id, [FromBody] UpdateMedicalRecordDto updateMedicalRecordDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ResponseDto response = new ResponseDto();
			try
			{
				MedicalRecordDto medicalRecord = _medicalRecordService.UpdateMedicalRecord(id, updateMedicalRecordDto);
				return Ok(medicalRecord);
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

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			ResponseDto response = new ResponseDto();
			try
			{
				response.Message = _medicalRecordService.DeleteMedicalRecord(id);
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
