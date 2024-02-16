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
public class TagAPIController : ControllerBase
{
	private readonly AppDbContext _db;
	private readonly IMapper _mapper;
	private readonly ResponseDto _response;

	public TagAPIController(AppDbContext db, IMapper mapper)
	{
		_mapper = mapper;
		_db = db;
		_response = new ResponseDto();
	}

	[HttpPost]
	public IActionResult Post([FromBody] TagDto newTag)
	{
		try
		{
			var tag = new Tag
			{
				Id = Guid.NewGuid(),
				RestaurantId = newTag.RestaurantId,
				Name = newTag.Name
			};
			_db.Tags.Add(tag);
			_db.SaveChanges();
			_response.Result = _mapper.Map<TagDto>(tag);
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
			var obj = _db.Tags.First(r => r.Id == id);
			_db.Tags.Remove(obj);
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