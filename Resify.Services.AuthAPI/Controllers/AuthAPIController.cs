using Microsoft.AspNetCore.Mvc;
using Resify.Services.AuthAPI.Models.Dto;
using Resify.Services.AuthAPI.Services.IService;

namespace Resify.Services.AuthAPI.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthAPIController : ControllerBase
{
	private readonly IAuthService _authService;
	protected ResponseDto _response;

	public AuthAPIController(IAuthService authService)
	{
		_authService = authService;
		_response = new ResponseDto();
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
	{
		var errorMessage = await _authService.Register(model);

		if (!string.IsNullOrEmpty(errorMessage))
		{
			_response.IsSuccess = false;
			_response.Message = errorMessage;
			return BadRequest(_response);
		}

		return Ok(_response);
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
	{
		var loginResponse = await _authService.Login(model);

		if (loginResponse.User == null)
		{
			_response.IsSuccess = false;
			_response.Message = "Username or password is incorrect";
			return BadRequest(_response);
		}

		var cookieOptions = new CookieOptions
		{
			HttpOnly = true,
			Secure = true,
			SameSite = SameSiteMode.Lax,
			Path = "/",
			Expires = DateTime.UtcNow.AddHours(1)
		};

		Response.Cookies.Append("jwt", loginResponse.Token, cookieOptions);

		_response.Result = loginResponse;
		return Ok(_response);
	}

	[HttpPost("logout")]
	public async Task<IActionResult> Logout()
	{
		Response.Cookies.Delete("jwt");
		return Ok();
	}
}