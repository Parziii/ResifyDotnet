using AutoMapper;
using Resify.Services.RestaurantsAPI.Models;
using Resify.Services.RestaurantsAPI.Models.Dto;

namespace Resify.Services.RestaurantsAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<RestaurantDto, Restaurant>();
				config.CreateMap<Restaurant, RestaurantDto>();
			});
			return mappingConfig;
		}
	}
}
