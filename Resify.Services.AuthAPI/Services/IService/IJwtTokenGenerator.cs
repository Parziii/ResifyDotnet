using Resify.Services.AuthAPI.Models;

namespace Resify.Services.AuthAPI.Services.IService;

public interface IJwtTokenGenerator
{
	string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}