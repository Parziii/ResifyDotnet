using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resify.Services.ReservationAPI.Models.Dto
{
	public class OrderDetailsDto
	{
		public Guid OrderDetailsId { get; set; }
		public Guid ReservationDetailsId { get; set; }
		public ReservationDetailsDto? ReservationDetails { get; set; }
		public Guid ProductId { get; set; }
		public ProductDto? Product { get; set; }
		public int Count { get; set; }
	}
}
