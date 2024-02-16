namespace Resify.Services.AuthAPI.Models.Dto;

public class UserDto
{
	public string ID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public bool IsBuisness { get; set; }
}