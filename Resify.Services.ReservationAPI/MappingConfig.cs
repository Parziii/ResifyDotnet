using AutoMapper;
using Resify.Services.ReservationAPI.Models;
using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<OrderDetailsDto, OrderDetails>();
				config.CreateMap<OrderDetails, OrderDetailsDto >();
				config.CreateMap<ReservationHeaderDto, ReservationHeader>();
				config.CreateMap<ReservationHeader, ReservationHeaderDto >();
				config.CreateMap<ReservationDetailsDto, ReservationDetails>();
				config.CreateMap<ReservationDetails, ReservationDetailsDto >();
			});
			return mappingConfig;
		}
	}
}
