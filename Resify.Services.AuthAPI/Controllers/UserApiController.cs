using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Resify.Services.AuthAPI.Models.Dto;
using Resify.Services.AuthAPI.Services.IService;

namespace Resify.Services.AuthAPI.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserAPIController : ControllerBase
	{
		private readonly IAuthService _authService;
		protected ResponseDto _response;

		public UserAPIController(IAuthService authService)
		{
			_authService = authService;
			_response = new();
		}

		[HttpGet]
		public IActionResult GetUserInfo()
		{

			Request.Cookies.TryGetValue("jwt", out string token);
			var claimsIdentity = this.User.Identity as ClaimsIdentity;
			var emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

			if (emailClaim != null)
			{
				var email = emailClaim.Value;
				return Ok(new { Email = email });
			}

			return BadRequest("Email claim not found in token");
		}
	}
}
