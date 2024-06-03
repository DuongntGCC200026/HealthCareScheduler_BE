using HealthCareScheduler.Models;
using NuGet.Protocol.Plugins;

namespace HealthCareScheduler.Repositories.Interface
{
	public interface IBranchRepository
	{
		void CreateBranch(Branch branch);
		Branch GetBranchByName(string name);
		Branch GetBranchById(Guid id);
		List<Branch> GetAllBranch(int limit);
		void UpdateBranch(Branch branch);
		void DeleteBranch(Branch branch);
		bool CheckUpdate(string name, Guid guid);
	}
}
