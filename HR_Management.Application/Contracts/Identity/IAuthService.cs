using HR_Management.Application.Models.Identity.Login;
using HR_Management.Application.Models.Identity.Register;

namespace HR_Management.Application.Contracts.Identity
{
    public interface IAuthService
    {
        public Task<LoginResponseModel> Login(LoginRequestModel request);
        public Task<RegisterResponseModel> Login(RegisterRequestModel request);
    }
}
