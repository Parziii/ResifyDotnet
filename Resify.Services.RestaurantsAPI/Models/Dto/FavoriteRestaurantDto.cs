namespace Resify.Services.RestaurantsAPI.Models.Dto;

public class FavoriteRestaurantDto
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public Guid RestaurantId { get; set; }
}