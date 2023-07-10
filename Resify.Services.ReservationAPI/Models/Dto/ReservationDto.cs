namespace Resify.Services.ReservationAPI.Models.Dto
{
	public class ReservationDto
	{
		public ReservationHeaderDto ReservationHeader { get; set; }
		public IEnumerable<ReservationDetailsDto>? ReservationDetails { get; set; }
	}
}
