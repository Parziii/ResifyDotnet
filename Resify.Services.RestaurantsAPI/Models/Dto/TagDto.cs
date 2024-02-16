namespace Resify.Services.RestaurantsAPI.Models.Dto;

public class TagDto
{
	public Guid? Id { get; set; }
	public Guid RestaurantId { get; set; }
	public string Name { get; set; }
}