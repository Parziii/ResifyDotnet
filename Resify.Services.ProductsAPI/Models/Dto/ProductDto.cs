namespace Resify.Services.ProductsAPI.Models.Dto
{
	public class ProductDto
	{
		public Guid Id { get; set; }
		public Guid RestaurantId { get; set; }
		public string Name { get; set; }
		public Guid CategoryId { get; set; }
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
	}
}
