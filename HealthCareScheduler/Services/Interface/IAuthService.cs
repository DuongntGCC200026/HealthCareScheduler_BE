using HealthCareScheduler.Dto.Auth;

namespace HealthCareScheduler.Services.Interface
{
    public interface IAuthService
    {
        string Register(RegisterDto registerDto);
        AuthResponse Login(LoginDto loginDto);
    }
}
