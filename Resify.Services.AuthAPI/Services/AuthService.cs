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
				UserName = registrationRequestDto.UserName,
				Email = registrationRequestDto.Email,
				NormalizedEmail = registrationRequestDto.Email.ToUpper(),
				FirstName = registrationRequestDto.FirstName,
				Surname = registrationRequestDto.Surname,
				Age = registrationRequestDto.Age,
				PhoneNumber = registrationRequestDto.PhoneNumber
			};

			try
			{
				var result =await _userManager.CreateAsync(user, registrationRequestDto.Password);
				if (result.Succeeded)
				{
					var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.UserName);

					UserDto userDto = new()
					{
						ID = userToReturn.Id,
						UserName = userToReturn.UserName,
						FirstName = userToReturn.FirstName,
						Surname = userToReturn.Surname,
						Email = userToReturn.Email,
						Age = userToReturn.Age,
						PhoneNumber = userToReturn.PhoneNumber,
						BusinessAccount = userToReturn.BusinessAccount
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
				u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

			bool isValid = user != null && await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

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
				UserName = user.UserName,
				FirstName = user.FirstName,
				Surname = user.Surname,
				Email = user.Email,
				Age = user.Age,
				PhoneNumber = user.PhoneNumber,
				BusinessAccount = user.BusinessAccount
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
