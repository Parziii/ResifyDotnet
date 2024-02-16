using Resify.Services.RestaurantsAPI.Models;

namespace Resify.Services.RestaurantsAPI.Services.Interfaces;

public interface IFavoriteRestaurantService
{
	List<FavoriteRestaurant> ReturnFavoriteRestaurants(Guid id);
}