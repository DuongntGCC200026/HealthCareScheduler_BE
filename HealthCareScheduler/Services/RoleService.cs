using AutoMapper;
using HealthCareScheduler.Dto.User;
using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using HealthCareScheduler.Services.Interface;

namespace HealthCareScheduler.Services
{
	public class RoleService : IRoleService
	{
		private readonly IMapper _mapper;
		private readonly IRoleRepository _roleRepository;

		public RoleService(IMapper mapper, IRoleRepository roleRepository)
		{
			_mapper = mapper;
			_roleRepository = roleRepository;
		}

		public RoleDto GetRoleById(Guid id)
		{
			throw new NotImplementedException();
		}

		public RoleDto GetRoleByName(string name)
		{
			throw new NotImplementedException();
		}

		public List<RoleDto> GetRoles()
		{
			List<Role> roles = _roleRepository.GetRoles();
			return _mapper.Map<List<RoleDto>>(roles);
		}
	}
}
