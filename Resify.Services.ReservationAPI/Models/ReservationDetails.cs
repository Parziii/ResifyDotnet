using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI.Models
{
	public class ReservationDetails
	{
		[Key]
		public Guid ReservationDetailId { get; set; }
		public Guid ReservationHeaderId { get; set; }
		[ForeignKey("ReservationHeaderId")]
		public ReservationHeader ReservationHeader { get; set; }
		public Guid TableId { get; set; }
		[NotMapped]
		public TableDto Table { get; set; }
		[NotMapped]
		public IEnumerable<OrderDetails>? OrderDetails { get; set; }
	}
}
