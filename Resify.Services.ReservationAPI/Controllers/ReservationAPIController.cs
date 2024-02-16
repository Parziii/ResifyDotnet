using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resify.Services.ReservationAPI.Models.Dto;
using Resify.Services.ReservationAPI.Services;

namespace Resify.Services.ReservationAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReservationAPIController : ControllerBase
{

	private readonly ResponseDto _response;
	private IReservationService _reservationService;

	public ReservationAPIController(IReservationService reservationService)
	{
		_response = new ResponseDto();
		_reservationService = reservationService;
	}

	[HttpPost]
	public async Task<ResponseDto> AddReservation(ReservationDto reservationDto)
	{
		try
		{
			_reservationService.AddReservation(reservationDto);
		}
		catch (Exception ex)
		{
			_response.Message = ex.Message;
			_response.IsSuccess = false;
		}

		return _response;
	}

	[HttpGet]
	public async Task<ResponseDto> GetReservations()
	{
		try
		{
			Request.Cookies.TryGetValue("jwt", out var token);
			var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
			_response.Result = _reservationService.GetReservations(Guid.Parse(id.Value));
		}
		catch (Exception ex)
		{
			_response.Message = ex.Message;
			_response.IsSuccess = false;
		}

		return _response;
	}

	[HttpPut]
	public async Task<ResponseDto> UpdateReservation(ReservationDto reservationDto )
	{
		try
		{
			_reservationService.UpdateReservation(reservationDto);
		}
		catch (Exception ex)
		{
			_response.Message = ex.Message;
			_response.IsSuccess = false;
		}

		return _response;
	}

	[HttpDelete]
	[Route("{id:Guid}")]
	public async Task<ResponseDto> DeleteReservation(Guid id)
	{
		try
		{
			_reservationService.DeleteReservation(id);
		}
		catch (Exception ex)
		{
			_response.Message = ex.Message;
			_response.IsSuccess = false;
		}

		return _response;
	}

}