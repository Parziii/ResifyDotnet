using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Resify.MessageBus;
using Resify.Services.AuthAPI.Models.Dto;
using Resify.Services.AuthAPI.Services.IService;

namespace Resify.Services.AuthAPI.Controllers;

[Route("api/user")]
[ApiController]
public class UserAPIController : ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly IMessageBus _messageBus;
	private readonly IUserService _userService;
	protected ResponseDto _response;

	public UserAPIController(IUserService userService, IMessageBus messageBus, IConfiguration configuration)
	{
		_userService = userService;
		_response = new ResponseDto();
		_messageBus = messageBus;
		_configuration = configuration;
	}

	[HttpGet]
	public IActionResult GetUserInfo()
	{
		Request.Cookies.TryGetValue("jwt", out var token);
		var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

		if (emailClaim != null)
		{
			var email = emailClaim.Value;
			var result = _userService.GetUserInfo(email);
			return Ok(result.Result);
		}

		return BadRequest("Email claim not found in token");
	}

	[HttpGet]
	[Route("change-password")]
	public IActionResult ChangeUserPassword([FromBody] PasswordDto passwordObject)
	{
		Request.Cookies.TryGetValue("jwt", out var token);
		var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

		if (emailClaim != null)
		{
			var email = emailClaim.Value;
			try
			{
				_response.Result = _userService.ChangePassword(passwordObject, email);
			}
			catch (Exception ex)
			{
				return StatusCode(401, _response);
			}
		}

		return StatusCode(200, _response);
	}

	[HttpGet]
	[Route("change-personal-data")]
	public IActionResult ChangeUserPersonalData([FromBody] PersonalDataDto personalDataDto)
	{
		Request.Cookies.TryGetValue("jwt", out var token);
		var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

		if (emailClaim != null)
		{
			var email = emailClaim.Value;
			try
			{
				_response.Result = _userService.ChangePersonalData(personalDataDto);
			}
			catch (Exception ex)
			{
				return StatusCode(401, _response);
			}
		}

		return StatusCode(200, _response);
	}
}