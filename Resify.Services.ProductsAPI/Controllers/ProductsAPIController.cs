using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resify.Services.ProductsAPI.Data;
using Resify.Services.ProductsAPI.Models;
using Resify.Services.ProductsAPI.Models.Dto;

namespace Resify.Services.ProductsAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ProductsAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

		public ProductsAPIController(AppDbContext db, IMapper mapper)
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
				IEnumerable<Product> objList = _db.Products.ToList();
				_response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
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
				Product obj = _db.Products.First(r => r.Id == id);
				_response.Result = _mapper.Map<ProductDto>(obj);
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
				Product obj = _db.Products.First(r => r.Name.ToLower() == name.ToLower());
				_response.Result = _mapper.Map<ProductDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpPost]
		public ResponseDto Post([FromBody] ProductDto productDto)
		{
			try
			{
				Product obj = _mapper.Map<Product>(productDto);
				_db.Products.Add(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpPut]
		public ResponseDto Put([FromBody] ProductDto productDto)
		{
			try
			{
				Product obj = _mapper.Map<Product>(productDto);
				_db.Products.Update(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductDto>(obj);
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
				Product obj = _db.Products.First(r => r.Id == id);
				_db.Products.Remove(obj);
				_db.SaveChanges();
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpGet]
		[Route("category")]
		public ResponseDto GetCategories()
		{
			try
			{
				IEnumerable<ProductCategory> objList = _db.ProductCategories.ToList();
				_response.Result = _mapper.Map<IEnumerable<ProductCategoryDto>>(objList);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpGet]
		[Route("category/{id:Guid}")]
		public ResponseDto GetCategory(Guid id)
		{
			try
			{
				ProductCategory obj = _db.ProductCategories.First(r => r.Id == id);
				_response.Result = _mapper.Map<ProductCategoryDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpGet]
		[Route("category/GetByName/{name}")]
		public ResponseDto GetCategoryByName(string name)
		{
			try
			{
				ProductCategory obj = _db.ProductCategories.First(r => r.Name.ToLower() == name.ToLower());
				_response.Result = _mapper.Map<ProductCategoryDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpPost]
		[Route("category")]
		public ResponseDto PostCategory([FromBody] ProductCategoryDto productCategoryDto)
		{
			try
			{
				ProductCategory obj = _mapper.Map<ProductCategory>(productCategoryDto);
				_db.ProductCategories.Add(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductCategoryDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpPut]
		[Route("category")]
		public ResponseDto PutCategory([FromBody] ProductCategoryDto productCategoryDto)
		{
			try
			{
				ProductCategory obj = _mapper.Map<ProductCategory>(productCategoryDto);
				_db.ProductCategories.Update(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductCategoryDto>(obj);
			}
			catch (Exception e)
			{
				_response.IsSuccess = false;
				_response.Message = e.Message;
			}

			return _response;
		}

		[HttpDelete]
		[Route("category")]
		public ResponseDto DeleteCategory(Guid id)
		{
			try
			{
				ProductCategory obj = _db.ProductCategories.First(r => r.Id == id);
				_db.ProductCategories.Remove(obj);
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
