using System.ComponentModel.DataAnnotations;

namespace Resify.Services.RestaurantsAPI.Models
{
	public class Restaurant
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string ZipCode { get; set; }
	}
}
