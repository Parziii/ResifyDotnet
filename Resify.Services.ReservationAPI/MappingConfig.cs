using AutoMapper;
using Resify.Services.ReservationAPI.Models;
using Resify.Services.ReservationAPI.Models.Dto;

namespace Resify.Services.ReservationAPI;

public class MappingConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		var mappingConfig = new MapperConfiguration(config =>
		{
			config.CreateMap<ReservationDto, Reservation>();
			config.CreateMap<Reservation, ReservationDto>();
		});
		return mappingConfig;
	}
}