using Microsoft.AspNetCore.Identity;
using Resify.Services.AuthAPI.Data;
using Resify.Services.AuthAPI.Models;
using Resify.Services.AuthAPI.Models.Dto;
using Resify.Services.AuthAPI.Services.IService;

namespace Resify.Services.AuthAPI.Services
{
	public class UserService : IUserService
	{
		private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;


		public UserService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u =>
				u.Email.ToLower() == loginRequestDto.Email.ToLower());

			var roles = await _userManager.GetRolesAsync(user);
			var token = _jwtTokenGenerator.GenerateToken(user, roles);

			UserDto userDto = new()
			{
				ID = user.Id,
				FirstName = user.FirstName,
				LastName = user.Surname,
				Email = user.Email,
				IsBuisness = user.BusinessAccount
			};

			LoginResponseDto loginResponseDto = new LoginResponseDto()
			{
				User = userDto,
				Token = token
			};

			return loginResponseDto;
		}
	}
}
