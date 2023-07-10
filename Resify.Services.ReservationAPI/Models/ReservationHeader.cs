using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resify.Services.ReservationAPI.Models
{
	public class ReservationHeader
	{
		[Key]
		public Guid ReservationHeaderId { get; set; }
		public string? UserId { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? StarTime { get; set; }
		public DateTime? EndTime { get; set; }
 		[NotMapped]
		public double ReservationTotal { get; set; }
	}
}
