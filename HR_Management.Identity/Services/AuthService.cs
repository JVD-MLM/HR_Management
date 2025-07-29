using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity.Login;
using HR_Management.Application.Models.Identity.Register;
using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HR_Management.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<JwtSetting> _jwtOptions;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, IOptions<JwtSetting> options, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtOptions = options;
            _signInManager = signInManager;
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

        public Task<LoginResponseModel> Login(LoginRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in userRoles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("username", user.UserName),
            }.Union(userClaims).Union(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.Value.Duration),
                signingCredentials: signingCredentials);

            return token;
        }
    }
}
