using System.ComponentModel.DataAnnotations;

namespace HealthCareScheduler.Dto.User
{
    public class UpdateUserDto : CreateUserDto
    {
        public Guid UserId { get; set; }
    }
}
