using HealthCareScheduler.Dto.Branch;

namespace HealthCareScheduler.Services.Interface
{
	public interface IBranchService
	{
		BranchDto AddBranch(CreateBranchDto branchDto);
		BranchDto UpdateBranch(Guid id, UpdateBranchDto branchDto);
		string DeleteBranch(Guid id);
		BranchDto GetBranchById(Guid id);
		BranchDto GetBranchByName(string name);
		List<BranchDto> GetAllBranch(int limit);
	}
}
