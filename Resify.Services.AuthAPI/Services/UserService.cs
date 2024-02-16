using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Resify.MessageBus;
using Resify.Services.AuthAPI.Data;
using Resify.Services.AuthAPI.Models;
using Resify.Services.AuthAPI.Models.Dto;
using Resify.Services.AuthAPI.Services.IService;
using Resify.Services.ReservationAPI.Messaging;

namespace Resify.Services.AuthAPI.Services;

public class UserService : IUserService
{
	private readonly IAzureServiceBusConsumer _busConsumer;
	private readonly IConfiguration _configuration;
	private readonly AppDbContext _db;
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IMessageBus _messageBus;
	private readonly RoleManager<IdentityRole> _roleManager;
	private readonly UserManager<ApplicationUser> _userManager;


	public UserService(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
		IJwtTokenGenerator jwtTokenGenerator, IMessageBus messageBus, IConfiguration configuration,
		IAzureServiceBusConsumer busConsumer)
	{
		_db = db;
		_userManager = userManager;
		_roleManager = roleManager;
		_jwtTokenGenerator = jwtTokenGenerator;
		_messageBus = messageBus;
		_configuration = configuration;
		_busConsumer = busConsumer;
	}

	public async Task<LoginResponseDto> ChangePassword(PasswordDto passwordObject, string mail)
	{
		var user = _db.ApplicationUsers.FirstOrDefault(u =>
			u.Email.ToLower() == mail.ToLower());

		var isValid = user != null && await _userManager.CheckPasswordAsync(user, passwordObject.currentPwd);

		if (user == null || isValid == false) throw new InvalidOperationException("Wrong password");

		await _userManager.ChangePasswordAsync(user, passwordObject.currentPwd, passwordObject.newPwd);

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

		var loginResponseDto = new LoginResponseDto
		{
			User = userDto,
			Token = token
		};

		return loginResponseDto;
	}

	public async Task<UserFavDto> GetUserInfo(string mail)
	{
		var user = _db.ApplicationUsers.FirstOrDefault(u =>
			u.Id == mail);

		if (user == null) throw new InvalidOperationException("Wrong user");

		await _messageBus.PublishMessage(user.Id,
			_configuration.GetValue<string>("TopicAndQueueNames:RestaurantRequestQueue"));

		var result = await _busConsumer.GetRestaurantInfo(
			_configuration.GetValue<string>("TopicAndQueueNames:RestaurantRequestTopic"),
			"FavoriteRestaurants", Guid.Parse(user.Id));

		var rest = JsonConvert.DeserializeObject<List<FavoriteRestaurantDto>>(result);

		UserFavDto userDto = new()
		{
			ID = user.Id,
			FirstName = user.FirstName,
			LastName = user.Surname,
			Email = user.Email,
			IsBuisness = user.BusinessAccount,
			FavouriteRestaurants = rest
		};

		return userDto;
	}

	public async Task<LoginResponseDto> ChangePersonalData(PersonalDataDto personalDataDto)
	{
		var user = _db.ApplicationUsers.FirstOrDefault(u =>
			u.Email.ToLower() == personalDataDto.Email.ToLower());

		var isValid = user != null && await _userManager.CheckPasswordAsync(user, personalDataDto.Pwd);

		if (user == null || isValid == false) throw new InvalidOperationException("Wrong password");

		user.FirstName = personalDataDto.FirstName;
		user.Surname = personalDataDto.LastName;
		user.Email = personalDataDto.Email;

		var result = await _userManager.UpdateAsync(user);
		if (!result.Succeeded) throw new InvalidOperationException("Failed to update user data.");

		user.NormalizedEmail = _userManager.NormalizeEmail(personalDataDto.Email);
		await _userManager.UpdateNormalizedEmailAsync(user);

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

		var loginResponseDto = new LoginResponseDto
		{
			User = userDto,
			Token = token
		};

		return loginResponseDto;
	}
}