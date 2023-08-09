using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resify.Services.RestaurantsAPI.Data;
using Resify.Services.RestaurantsAPI.Models;
using Resify.Services.RestaurantsAPI.Models.Dto;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Resify.Services.RestaurantsAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class RestaurantsAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

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
				Restaurant obj = _db.Restaurants.First(r => r.Id == id);
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
		[Route("GetByName/{name}")]
		public ResponseDto GetByName(string name)
		{
			try
			{
				Restaurant obj = _db.Restaurants.First(r => r.Name.ToLower() == name.ToLower());
				_response.Result = _mapper.Map<RestaurantDto>(obj);
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
				Restaurant obj = _mapper.Map<Restaurant>(restaurantDto);
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
				Restaurant obj = _mapper.Map<Restaurant>(restaurantDto);
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
				Restaurant obj = _db.Restaurants.First(r => r.Id == id);
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
}
