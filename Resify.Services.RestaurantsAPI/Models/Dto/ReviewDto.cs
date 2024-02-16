namespace Resify.Services.RestaurantsAPI.Models.Dto
{
	public class ReviewDto
	{
		public Guid Id { get; set; }
		public Guid RestaurantId { get; set; }
		public string? Description { get; set; }
		public int Rate { get; set; }
	}
}
