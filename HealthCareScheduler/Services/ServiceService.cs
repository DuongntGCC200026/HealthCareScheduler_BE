using AutoMapper;
using HealthCareScheduler.Dto.Branch;
using HealthCareScheduler.Dto.Service;
using HealthCareScheduler.Exceptions;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using HealthCareScheduler.Services.Interface;

namespace HealthCareScheduler.Services
{
	public class ServiceService : IServiceService
	{
		private readonly IMapper _mapper;
		private readonly IServiceRepository _serviceRepository;

		public ServiceService(IMapper mapper, IServiceRepository serviceRepository)
		{
			_mapper = mapper;
			_serviceRepository = serviceRepository;
		}

		public ServiceDto AddService(CreateServiceDto serviceDto)
		{
			Service service = _mapper.Map<Service>(serviceDto);

			Service existingService = _serviceRepository.GetServiceByName(serviceDto.ServiceName);
			if (existingService != null)
			{
				throw new ConflictException("Service with the same name already exists");
			}

			_serviceRepository.CreateService(service);

			return _mapper.Map<ServiceDto>(service);
		}

		public string DeleteService(Guid id)
		{
			Service existingService = _serviceRepository.GetServiceById(id);
			if (existingService == null)
			{
				throw new NotFoundException("Service does not exist");
			}

			_serviceRepository.DeleteService(existingService);

			return "Delete successful";
		}

		public List<ServiceDto> GetAllService(int limit)
		{
			List<Service> services = _serviceRepository.GetAllServices(limit);
			return _mapper.Map<List<ServiceDto>>(services);
		}

		public ServiceDto GetServiceById(Guid id)
		{
			Service service = _serviceRepository.GetServiceById(id);
			if (service == null)
			{
				throw new NotFoundException("Service does not exist");
			}

			return _mapper.Map<ServiceDto>(service);
		}

		public ServiceDto GetServiceByName(string name)
		{
			Service service = _serviceRepository.GetServiceByName(name);
			if (service == null)
			{
				throw new NotFoundException("Service does not exist");
			}

			return _mapper.Map<ServiceDto>(service);
		}

		public ServiceDto UpdateService(Guid id, UpdateServiceDto serviceDto)
		{
			Service existingService = _serviceRepository.GetServiceById(id);
			if (existingService == null)
			{
				throw new NotFoundException("Service does not exist");
			}
			if (_serviceRepository.CheckUpdate(serviceDto.ServiceName, id))
			{
				throw new ConflictException("Service already exists");
			}

			// Update service properties
			_mapper.Map(serviceDto, existingService);
			existingService.ServiceId = id;

			_serviceRepository.UpdateService(existingService);

			return _mapper.Map<ServiceDto>(existingService);
		}
	}
}
