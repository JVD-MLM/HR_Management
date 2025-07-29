using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity.Login;
using HR_Management.Application.Models.Identity.Register;
using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace HR_Management.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtSetting> _options;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSetting> options, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _options = options;
            _signInManager = signInManager;
        }

        public Task<LoginResponseModel> Login(LoginRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<RegisterResponseModel> Register(RegisterRequestModel request)
        {
            var existUser = await _userManager.FindByNameAsync(request.Username);

            if (existUser != null)
            {
                throw new Exception();
            }

            var user = new ApplicationUser()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                EmailConfirmed = true
            };

            var existEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Employee");
                    return new RegisterResponseModel() { Id = user.Id };
                }
                else
                {
                    throw new Exception();
                }

            }
            else
            {
                throw new Exception();
            }
        }
    }
}
