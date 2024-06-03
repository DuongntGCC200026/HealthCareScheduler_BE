using HealthCareScheduler.Dto.Service;
using HealthCareScheduler.Models;

namespace HealthCareScheduler.Repositories.Interface
{
	public interface IServiceRepository
	{
		void CreateService(Service service);
		Service GetServiceByName(string name);
		Service GetServiceById(Guid id);
		List<Service> GetAllServices(int limit);
		void UpdateService(Service service);
		void DeleteService(Service service);
		bool CheckUpdate(string name, Guid id);
	}
}
