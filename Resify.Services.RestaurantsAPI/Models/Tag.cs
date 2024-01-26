using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resify.Services.RestaurantsAPI.Models
{
	public class Tag
	{
		[Key]
		public Guid Id { get; set; }
		public Restaurant Restaurant { get; set; }
		[ForeignKey("Restaurant")]
		public Guid RestaurantId { get; set; }
		public string Name { get; set; }
	}
}
