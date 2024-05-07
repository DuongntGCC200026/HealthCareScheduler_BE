using AutoMapper;
using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using HealthCareScheduler.Services.Interface;
using NuGet.Protocol.Plugins;

namespace HealthCareScheduler.Services
{
	public class BranchService : IBranchService
	{
		private readonly IMapper _mapper;
		private readonly IBranchRepository _branchRepository;

		public BranchService(IMapper mapper, IBranchRepository repository)
		{
			_mapper = mapper;
			_branchRepository = repository;
		}
		public BranchDto AddBranch(CreateBranchDto branchDto)
		{
			Branch branch = _branchRepository.GetBranchByName(branchDto.Name);

			if (branch != null)
			{
				throw new ConflictException("Branch already exists");
			}

			branch = _mapper.Map<Branch>(branchDto);
			_branchRepository.CreateBranch(branch);

			return _mapper.Map<BranchDto>(branch);
		}

		public string DeleteBranch(Guid id)
		{
			Branch branch = _branchRepository.GetBranchById(id) ?? throw new NotFoundException("Branch does not exist");
			_branchRepository.DeleteBranch(branch);

			return "Delete successful";

		}

		public List<BranchDto> GetAllBranch(int limit)
		{
			List<Branch> branchList = _branchRepository.GetAllBranch(limit);
			return _mapper.Map<List<BranchDto>>(branchList);
		}

		public BranchDto GetBranchById(Guid id)
		{
			Branch branch = _branchRepository.GetBranchById(id) ?? throw new NotFoundException("Branch does not exist");

			return _mapper.Map<BranchDto>(branch);
		}

		public BranchDto GetBranchByName(string name)
		{
			Branch branch = _branchRepository.GetBranchByName(name);
			if (branch == null)
			{
				throw new NotFoundException("Branch does not exist");
			}

			return _mapper.Map<BranchDto>(branch);
		}

		public BranchDto UpdateBranch(Guid id, UpdateBranchDto updateBranchDto)
		{
			_ = _branchRepository.GetBranchById(id) ?? throw new NotFoundException("Branch does not exist");

			updateBranchDto.BranchId = id;

			Branch branchToUpdate = _mapper.Map<Branch>(updateBranchDto);
			_branchRepository.UpdateBranch(branchToUpdate);

			return _mapper.Map<BranchDto>(branchToUpdate);
		}
	}
}
