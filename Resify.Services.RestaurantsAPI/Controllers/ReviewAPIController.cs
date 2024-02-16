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
public class ReviewAPIController : ControllerBase
{
	private readonly AppDbContext _db;
	private readonly IMapper _mapper;
	private readonly ResponseDto _response;

	public ReviewAPIController(AppDbContext db, IMapper mapper)
	{
		_mapper = mapper;
		_db = db;
		_response = new ResponseDto();
	}

	[HttpPost]
	public IActionResult Post([FromBody] ReviewDto newReview)
	{
		try
		{
			var review = new Review()
			{
				Id = Guid.NewGuid(),
				RestaurantId = newReview.RestaurantId,
				Description = newReview.Description,
				Rate = newReview.Rate,
			};
			_db.Reviews.Add(review);
			_db.SaveChanges();
			_response.Result = _mapper.Map<ReviewDto>(review);
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
			return StatusCode(500, _response);
		}


		return StatusCode(201, _response);
	}

	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id)
	{
		try
		{
			var obj = _db.Reviews.First(r => r.Id == id);
			_db.Reviews.Remove(obj);
			_db.SaveChanges();
		}
		catch (Exception e)
		{
			_response.IsSuccess = false;
			_response.Message = e.Message;
			return StatusCode(500, _response);
		}


		return StatusCode(200, _response);
	}
}