using System.ComponentModel.DataAnnotations;

namespace Resify.Services.ProductsAPI.Models
{
	public class ProductCategory
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}
