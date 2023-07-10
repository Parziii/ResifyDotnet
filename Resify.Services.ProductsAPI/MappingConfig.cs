using AutoMapper;
using Resify.Services.ProductsAPI.Models;
using Resify.Services.ProductsAPI.Models.Dto;

namespace Resify.Services.ProductsAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ProductDto, Product>();
				config.CreateMap<Product, ProductDto>();
				config.CreateMap<ProductCategory, ProductCategoryDto>();
				config.CreateMap<ProductCategoryDto, ProductCategory>();
			});
			return mappingConfig;
		}
	}
}
