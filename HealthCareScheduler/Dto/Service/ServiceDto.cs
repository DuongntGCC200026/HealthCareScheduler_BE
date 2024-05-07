using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Dto.Service
{
	public class ServiceDto
	{
		public Guid ServiceId { get; set; }

		[StringLength(50)]
		public string ServiceName { get; set; }

		[StringLength(100)]
		public string ServiceDescription { get; set; }
	}
}
