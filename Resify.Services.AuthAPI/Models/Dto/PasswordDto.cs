using System.ComponentModel.DataAnnotations;

namespace Resify.Services.AuthAPI.Models.Dto;

public class PasswordDto
{
	[Required] public string currentPwd { get; set; }

	[Required] public string newPwd { get; set; }
}