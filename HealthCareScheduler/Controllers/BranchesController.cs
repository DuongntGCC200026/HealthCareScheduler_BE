using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Dto;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareScheduler.Controllers
{
	[Route("api/branch")]
	[ApiController]
	public class BranchesController : ControllerBase
	{
		private readonly IBranchService _branchService;

		public BranchesController(IBranchService branchService)
		{
			_branchService = branchService;
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Get(int limit)
		{
			List<BranchDto> branches = _branchService.GetAllBranch(limit);
			return Ok(branches);
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			ResponseDto response = new ResponseDto();
			try
			{
				BranchDto branchDto = _branchService.GetBranchById(id);
				return Ok(branchDto);
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
		public IActionResult Post([FromBody] CreateBranchDto createBranchDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ResponseDto response = new ResponseDto();
			try
			{
				BranchDto branchDto = _branchService.AddBranch(createBranchDto);
				return Ok(branchDto);
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
		public IActionResult Put(Guid id, [FromBody] UpdateBranchDto updateBranchDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			ResponseDto response = new ResponseDto();
			try
			{
				BranchDto branch = _branchService.UpdateBranch(id, updateBranchDto);
				return Ok(branch);
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
				response.Message = _branchService.DeleteBranch(id);
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
