using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Dto.Service;

namespace HealthCareScheduler.Services.Interface
{
	public interface IServiceService
	{
		ServiceDto AddService(CreateServiceDto serviceDto);
		ServiceDto UpdateService(Guid id, UpdateServiceDto serviceDto);
		string DeleteService(Guid id);
		ServiceDto GetServiceById(Guid id);
		List<ServiceDto> GetAllService(int limit);
	}
}
