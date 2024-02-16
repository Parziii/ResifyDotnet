namespace Resify.Services.AuthAPI.Models.Dto;

public class UserFavDto
{
	public string ID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public bool IsBuisness { get; set; }
	public List<FavoriteRestaurantDto> FavouriteRestaurants { get; set; }
}

public class FavoriteRestaurantDto
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public Guid RestaurantId { get; set; }
}