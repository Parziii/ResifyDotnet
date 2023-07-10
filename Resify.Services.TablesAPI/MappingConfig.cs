using AutoMapper;
using Resify.Services.TablesAPI.Models;
using Resify.Services.TablesAPI.Models.Dto;

namespace Resify.Services.TablesAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<Table, TableDto>();
				config.CreateMap<TableDto, Table>();
			});
			return mappingConfig;
		}
	}
}
