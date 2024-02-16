using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resify.Services.RestaurantsAPI.Data;
using Resify.Services.RestaurantsAPI.Models;
using Resify.Services.RestaurantsAPI.Models.Dto;

namespace Resify.Services.RestaurantsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FavoriteAPIController : ControllerBase
{
	private readonly AppDbContext _db;
	private readonly IMapper _mapper;
	private readonly ResponseDto _response;

	public FavoriteAPIController(AppDbContext db, IMapper mapper)
	{
		_mapper = mapper;
		_db = db;
		_response = new ResponseDto();
	}

	[HttpPost]
	public IActionResult Post([FromBody] RestaurantIdDto restaurant)
	{
		Request.Cookies.TryGetValue("jwt", out var token);
		var nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

		if (nameClaim != null)
		{
			var name = nameClaim.Value;

			try
			{
				var favorite = new FavoriteRestaurant
				{
					Id = Guid.NewGuid(),
					RestaurantId = restaurant.RestaurantId,
					UserId = Guid.Parse(name)
				};
				_db.FavoriteRestaurants.Add(favorite);
				_db.SaveChanges();
				_response.Result = _mapper.Map<FavoriteRestaurantDto>(favorite);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
				return StatusCode(500, _response);
			}
		}

		return StatusCode(201, _response);
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id)
	{
		Request.Cookies.TryGetValue("jwt", out var token);
		var nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

		if (nameClaim != null)
		{
			var name = nameClaim.Value;
			try
			{
				var obj = _db.FavoriteRestaurants.First(r => r.RestaurantId == id && r.UserId == Guid.Parse(name));
				_db.FavoriteRestaurants.Remove(obj);
				_db.SaveChanges();
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
				return StatusCode(500, _response);
			}
		}

		return StatusCode(200, _response);
	}
}