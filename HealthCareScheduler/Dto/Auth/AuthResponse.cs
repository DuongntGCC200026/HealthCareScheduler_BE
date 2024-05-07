using HealthCareScheduler.Constraints;
using HealthCareScheduler.Dto.User;

namespace HealthCareScheduler.Dto.Auth
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string Role { get; set; }
        public UserDto User { get; set; }
    }
}
