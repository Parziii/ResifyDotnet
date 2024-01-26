using System.ComponentModel.DataAnnotations;

namespace Resify.Services.RestaurantsAPI.Models.Dto
{
	public class RestaurantDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string ZipCode { get; set; }
		public int FavoriteCount { get; set; }
		public bool IsFavorite { get; set; }
		public TagDto? Tags { get; set; }
		public Guid OwnerId { get; set; }
	}
}
