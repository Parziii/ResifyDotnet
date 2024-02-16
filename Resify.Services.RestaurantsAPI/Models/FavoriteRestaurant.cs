using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resify.Services.RestaurantsAPI.Models;

public class FavoriteRestaurant
{
	[Key] public Guid Id { get; set; }

	[Required] public Guid UserId { get; set; }

	public Restaurant Restaurant { get; set; }

	[ForeignKey("Restaurant")] public Guid RestaurantId { get; set; }
}