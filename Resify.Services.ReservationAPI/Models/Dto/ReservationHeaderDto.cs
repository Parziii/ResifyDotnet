using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Resify.Services.ReservationAPI.Models.Dto
{
	public class ReservationHeaderDto
	{
		public Guid ReservationHeaderId { get; set; }
		public string? UserId { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? StarTime { get; set; }
		public DateTime? EndTime { get; set; }
		public double ReservationTotal { get; set; }
	}
}
