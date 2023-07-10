using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resify.Services.TablesAPI.Data;
using Resify.Services.TablesAPI.Models;
using Resify.Services.TablesAPI.Models.Dto;

namespace Resify.Services.TablesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TablesAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

		public TablesAPIController(AppDbContext db, IMapper mapper)
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
				IEnumerable<Table> objList = _db.Tables.ToList();
				_response.Result = _mapper.Map<IEnumerable<TableDto>>(objList);
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
				Table obj = _db.Tables.First(r => r.Id == id);
				_response.Result = _mapper.Map<TableDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpGet]
		[Route("GetByRestaurant/{id}")]
		public ResponseDto GetByRestaurant(Guid id)
		{
			try
			{
				IEnumerable<Table> objList = _db.Tables.Where(r => r.RestaurantId == id);
				_response.Result = _mapper.Map<IEnumerable<TableDto>>(objList);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpPost]
		public ResponseDto Post([FromBody] TableDto tableDto)
		{
			try
			{
				Table obj = _mapper.Map<Table>(tableDto);
				_db.Tables.Add(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<TableDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpPut]
		public ResponseDto Put([FromBody] TableDto tableDto)
		{
			try
			{
				Table obj = _mapper.Map<Table>(tableDto);
				_db.Tables.Update(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<TableDto>(obj);
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
				Table obj = _db.Tables.First(r => r.Id == id);
				_db.Tables.Remove(obj);
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
