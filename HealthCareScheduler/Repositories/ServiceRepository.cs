using HealthCareScheduler.Models;
using HealthCareScheduler.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace HealthCareScheduler.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

		public bool CheckUpdate(string name, Guid id)
		{
			try
			{
				Service service = _context.Services.AsNoTracking().FirstOrDefault(u => u.ServiceName == name);
				if (service != null)
				{
					if (service.ServiceId != id)
					{
						return true;
					}
				}
				return false;
			}
			catch (Exception)
			{
				throw new Exception("Error checking Academic Year");
			}
		}

		public void CreateService(Service service)
        {
            try
            {
                _context.Services.Add(service);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error creating service");
            }
        }

        public void DeleteService(Service service)
        {
            try
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error deleting service");
            }
        }

        public List<Service> GetAllServices(int limit)
        {
            try
            {
                if (limit == 0)
                {
                    return _context.Services.OrderBy(u => u.ServiceName).ToList();
                }
                else
                {
                    return _context.Services.Take(limit).ToList();
                }
            }
            catch (Exception)
            {
                throw new Exception("Error fetch service");
            }
        }

        public Service GetServiceById(Guid id)
        {
            try
            {
                return _context.Services.Where(u => u.ServiceId == id).AsNoTracking().FirstOrDefault();
            }
            catch (Exception)
            {
                throw new Exception("Error getting service");
            }
        }

        public Service GetServiceByName(string name)
        {
            try
            {
                Service service = _context.Services.FirstOrDefault(u => u.ServiceName == name);
                return service;
            }
            catch (Exception)
            {
                throw new Exception("Error getting service");
            }
        }

        public void UpdateService(Service service)
        {
            try
            {
                _context.Entry(service).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Error updating service");
            }
        }
    }
}
