using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Resify.Services.AuthAPI.Models;
using Resify.Services.AuthAPI.Services.IService;

namespace Resify.Services.AuthAPI.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
	private readonly JwtOptions _jwtOptions;

	public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
	{
		_jwtOptions = jwtOptions.Value;
	}

	public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.Email, applicationUser.Email),
			new(JwtRegisteredClaimNames.Name, applicationUser.Id)
		};

		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Audience = _jwtOptions.Audience,
			Issuer = _jwtOptions.Issuer,
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
				SecurityAlgorithms.HmacSha256Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}