using System.ComponentModel.DataAnnotations;

namespace Resify.Services.TablesAPI.Models.Dto
{
	public class TableDto
	{
		public Guid Id { get; set; }
		public Guid RestaurantId { get; set; }
		public string? Category { get; set; }
		public int ChairCount { get; set; }
	}
}
