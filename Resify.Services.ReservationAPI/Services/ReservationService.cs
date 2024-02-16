using AutoMapper;
using Resify.Services.ReservationAPI.Data;
using Resify.Services.ReservationAPI.Models;
using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI.Services
{
	public class ReservationService : IReservationService
	{
		private readonly AppDbContext _db;
		private IMapper _mapper;

		public ReservationService(AppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public void DeleteReservation(Guid id)
		{
			var objToRemove = _db.Reservations.FirstOrDefault(x => x.Id == id);
			if (objToRemove != null) _db.Reservations.Remove(objToRemove);
			_db.SaveChanges();
		}

		public void UpdateReservation(ReservationDto reservation)
		{
			_db.Reservations.Update(_mapper.Map<Reservation>(reservation));
			_db.SaveChanges();
		}

		public IEnumerable<ReservationDto> GetReservations(Guid userId)
		{
			var reservations = _db.Reservations.Where(x => x.UserId == userId).Select(x => _mapper.Map<ReservationDto>(x));
			
			return reservations;
		}

		public void AddReservation(ReservationDto reservation)
		{
			_db.Reservations.Add(_mapper.Map<Reservation>(reservation));
			_db.SaveChanges();
		}
	}
}
