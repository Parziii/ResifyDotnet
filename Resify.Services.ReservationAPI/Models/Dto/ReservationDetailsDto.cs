using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resify.Services.ReservationAPI.Models.Dto
{
	public class ReservationDetailsDto
	{
		public Guid ReservationDetailId { get; set; }
		public Guid ReservationHeaderId { get; set; }
		public ReservationHeaderDto? ReservationHeader { get; set; }
		public Guid TableId { get; set; }
		public TableDto? Table { get; set; }
		public IEnumerable<OrderDetailsDto>? OrderDetails { get; set; }
	}
}
