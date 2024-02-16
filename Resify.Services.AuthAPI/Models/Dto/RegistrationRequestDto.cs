namespace Resify.Services.AuthAPI.Models.Dto;

public class RegistrationRequestDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string Pwd { get; set; }
	public bool IsBusiness { get; set; }
}