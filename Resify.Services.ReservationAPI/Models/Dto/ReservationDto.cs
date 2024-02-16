using Resify.Services.ReservationAPI.Models.Enums;

namespace Resify.Services.ReservationAPI.Models.Dto;

public class ReservationDto
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime From { get; set; }
	public DateTime To { get; set; }
	public States State { get; set; }
	public int PeopleCount { get; set; }
	public Guid RestaurantId { get; set; }
}

public class UserDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
}

public class RestaurantDto
{
	public string Name { get; set; }
}