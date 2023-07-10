using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resify.Services.ReservationAPI.Data;
using Resify.Services.ReservationAPI.Models;
using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReservationAPIController : ControllerBase
	{
		private ResponseDto _response;
		private IMapper _mapper;
		private readonly AppDbContext _db;

		public ReservationAPIController(IMapper mapper, AppDbContext db)
		{
			_response = new ResponseDto();
			_mapper = mapper;
			_db = db;
		}

		[HttpPost("ReservationUpsert")]
		public async Task<ResponseDto> ReservUpsert(ReservationDto reservationDto)
		{
			try
			{
				var reservHeaderFromDb =
					await _db.ReservationHeaders.FirstOrDefaultAsync(u =>
						u.UserId == reservationDto.ReservationHeader.UserId);

				if (reservHeaderFromDb == null)
				{
					ReservationHeader reservationHeader = _mapper.Map<ReservationHeader>(reservationDto.ReservationHeader);
					_db.ReservationHeaders.Add(reservationHeader);
					await _db.SaveChangesAsync();

					if (reservationDto.ReservationDetails != null)
					{
						foreach (var detail in reservationDto.ReservationDetails)
						{
							detail.ReservationHeaderId = reservationHeader.ReservationHeaderId;
							_db.ReservationDetails.Add(_mapper.Map<ReservationDetails>(detail));
							await _db.SaveChangesAsync();

							if (detail.OrderDetails == null) continue;

							foreach (var order in detail.OrderDetails)
							{
								order.ReservationDetailsId = detail.ReservationDetailId;

								_db.OrderDetails.Add(_mapper.Map<OrderDetails>(order));
							}
						}
					}
				}
				else
				{
					var reservDetailsFromDb = await _db.ReservationDetails.FirstOrDefaultAsync(u =>
						u.TableId == reservationDto.ReservationDetails.First().TableId &&
						u.ReservationHeaderId == reservHeaderFromDb.ReservationHeaderId);

					if (reservDetailsFromDb == null)
					{
						
					}
					else
					{
						
					}
				}
			}
			catch (Exception ex)
			{
				_response.Message = ex.Message;
				_response.IsSuccess = false;
			}

			return _response;
		}
	}
}
