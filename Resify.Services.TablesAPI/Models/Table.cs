using System.ComponentModel.DataAnnotations;

namespace Resify.Services.TablesAPI.Models
{
	public class Table
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public Guid RestaurantId { get; set; }
		public string? Category { get; set; }
		[Range(1, 1000)]
		public int ChairCount { get; set; }
	}
}
