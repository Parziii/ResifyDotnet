using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resify.Services.ProductsAPI.Models
{
	public class Product
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public Guid RestaurantId { get; set; }
		[Required]
		public string Name { get; set; }
		[ForeignKey("ProductCategory")]
		public Guid ProductCategoryId { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
	}
}
