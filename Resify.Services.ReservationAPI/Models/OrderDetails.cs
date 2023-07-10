using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI.Models
{
	public class OrderDetails
	{
		[Key]
		public Guid OrderDetailsId { get; set; }
		public Guid ReservationDetailsId { get; set; }
		[ForeignKey("ReservationDetailsId")]
		public ReservationDetails ReservationDetails { get; set; }
		public Guid ProductId { get; set; }
		[NotMapped]
		public ProductDto Product { get; set; }
		public int Count { get; set; }
	}
}
