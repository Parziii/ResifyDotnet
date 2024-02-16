using System.ComponentModel.DataAnnotations;

namespace Resify.Services.AuthAPI.Models.Dto;

public class PersonalDataDto
{
	[Required] public string FirstName { get; set; }

	[Required] public string LastName { get; set; }

	[Required] public string Email { get; set; }

	[Required] public string Pwd { get; set; }
}