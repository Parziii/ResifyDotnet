using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI.Services
{
	public interface IReservationService
	{
		void DeleteReservation(Guid id);
		void UpdateReservation(ReservationDto reservation);
		IEnumerable<ReservationDto> GetReservations(Guid userId);
		void AddReservation(ReservationDto reservation);
	}
}
