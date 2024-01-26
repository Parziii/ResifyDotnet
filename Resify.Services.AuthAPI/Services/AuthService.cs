using Microsoft.AspNetCore.Identity;
using Resify.Services.AuthAPI.Data;
using Resify.Services.AuthAPI.Models;
using Resify.Services.AuthAPI.Models.Dto;
using Resify.Services.AuthAPI.Services.IService;

namespace Resify.Services.AuthAPI.Services
{
	public class AuthService : IAuthService
	{
		private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;


		public AuthService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
		{
			ApplicationUser user = new()
			{
				UserName = Guid.NewGuid().ToString(),
				Email = registrationRequestDto.Email,
				NormalizedEmail = registrationRequestDto.Email.ToUpper(),
				FirstName = registrationRequestDto.FirstName,
				Surname = registrationRequestDto.LastName,
				BusinessAccount = registrationRequestDto.IsBusiness
			};

			try
			{
				var result =await _userManager.CreateAsync(user, registrationRequestDto.Pwd);
				if (result.Succeeded)
				{
					var userToReturn = _db.ApplicationUsers.First(u => u.Email == registrationRequestDto.Email);

					UserDto userDto = new()
					{
						ID = userToReturn.Id,
						FirstName = userToReturn.FirstName,
						LastName = userToReturn.Surname,
						Email = userToReturn.Email,
						IsBuisness = userToReturn.BusinessAccount
					};

					return "";
				}

				return result.Errors.FirstOrDefault()!.Description;
			}
			catch (Exception e)
			{
				return $"Error ecountered: {e.Message}";
			}
		}

		public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u =>
				u.Email.ToLower() == loginRequestDto.Email.ToLower());

			bool isValid = user != null && await _userManager.CheckPasswordAsync(user, loginRequestDto.Pwd);

			if (user == null || isValid == false)
			{
				return new LoginResponseDto()
				{
					User = null,
					Token = ""
				};
			}

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

		public async Task<bool> AssignRole(string email, string roleName)
		{
			var user = _db.ApplicationUsers.FirstOrDefault(u =>
				u.Email.ToLower() == email);

			if (user == null)
			{
				if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
				{
					_roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
				}

				await _userManager.AddToRoleAsync(user, roleName);
				return true;
			}

			return false;
		}
	}
}
