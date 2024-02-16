using Resify.Services.RestaurantsAPI.Data;
using Resify.Services.RestaurantsAPI.Models;
using Resify.Services.RestaurantsAPI.Services.Interfaces;

namespace Resify.Services.RestaurantsAPI.Services;

public class FavoriteRestaurantService : IFavoriteRestaurantService
{
	private readonly AppDbContext _db;

	public FavoriteRestaurantService(AppDbContext db)
	{
		_db = db;
	}

	public List<FavoriteRestaurant> ReturnFavoriteRestaurants(Guid id)
	{
		return _db.FavoriteRestaurants.Where(x => x.UserId == id).ToList();
	}
}