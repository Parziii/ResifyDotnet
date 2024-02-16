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
public class RestaurantsAPIController : ControllerBase
{
	private readonly AppDbContext _db;
	private readonly IMapper _mapper;
	private readonly ResponseDto _response;

	public RestaurantsAPIController(AppDbContext db, IMapper mapper)
	{
		_mapper = mapper;
		_db = db;
		_response = new ResponseDto();
	}

	[HttpGet]
	public ResponseDto Get()
	{
		try
		{
			IEnumerable<Restaurant> objList = _db.Restaurants.ToList();
			_response.Result = _mapper.Map<IEnumerable<RestaurantDto>>(objList);
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
		}

		return _response;
	}

	[HttpGet]
	[Route("{id:Guid}")]
	public ResponseDto Get(Guid id)
	{
		try
		{
			var obj = _db.Restaurants.First(r => r.Id == id);
			_response.Result = _mapper.Map<RestaurantDto>(obj);
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
		}

		return _response;
	}

	[HttpGet]
	[Route("search")]
	public ResponseDto Search([FromQuery] string query)
	{
		try
		{
			var obj = _db.Restaurants.Where(r => r.Name.Contains(query)).ToList();
			_response.Result = _mapper.Map<List<RestaurantDto>>(obj);
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
		}

		return _response;
	}

	[HttpPost]
	public ResponseDto Post([FromBody] RestaurantDto restaurantDto)
	{
		try
		{
			var obj = _mapper.Map<Restaurant>(restaurantDto);
			_db.Restaurants.Add(obj);
			_db.SaveChanges();

			_response.Result = _mapper.Map<RestaurantDto>(obj);
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
		}

		return _response;
	}

	[HttpPut]
	public ResponseDto Put([FromBody] RestaurantDto restaurantDto)
	{
		try
		{
			var obj = _mapper.Map<Restaurant>(restaurantDto);
			_db.Restaurants.Update(obj);
			_db.SaveChanges();

			_response.Result = _mapper.Map<RestaurantDto>(obj);
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
		}

		return _response;
	}

	[HttpDelete]
	public ResponseDto Delete(Guid id)
	{
		try
		{
			var obj = _db.Restaurants.First(r => r.Id == id);
			_db.Restaurants.Remove(obj);
			_db.SaveChanges();
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
		}

		return _response;
	}
}