using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace HealthCareScheduler.Repositories
{
	public class BranchRepository : IBranchRepository
	{
		private readonly ApplicationDbContext _context;

		public BranchRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public void CreateBranch(Branch branch)
		{
			try
			{
				_context.Branches.Add(branch);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error creating branch");
			}
		}

		public void DeleteBranch(Branch branch)
		{
			try
			{
				_context.Branches.Remove(branch);
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error deleting branch");
			}
		}

		public List<Branch> GetAllBranch(int limit)
		{
			try
			{
				if (limit == 0)
				{
					return _context.Branches.Where(f => !f.Name.Equals("Admin")).ToList();
				}
				else
				{
					return _context.Branches.Where(f => !f.Name.Equals("Admin")).Take(limit).ToList();
				}
			}
			catch (Exception)
			{
				throw new Exception("Error fetch branch");
			}
		}

		public Branch GetBranchById(Guid id)
		{
			try
			{
				return _context.Branches.Where(u => u.BranchId == id).AsNoTracking().FirstOrDefault();
			}
			catch (Exception)
			{
				throw new Exception("Error getting branch");
			}
		}

		public Branch GetBranchByName(string name)
		{
			try
			{
				Branch faculty = _context.Branches.FirstOrDefault(u => u.Name == name);
				return faculty;
			}
			catch (Exception)
			{
				throw new Exception("Error getting branch");
			}
		}

		public void UpdateBranch(Branch branch)
		{
			try
			{
				_context.Entry<Branch>(branch).State = EntityState.Modified;
				_context.SaveChanges();
			}
			catch (Exception)
			{
				throw new Exception("Error updating branch");
			}
		}
	}
}
