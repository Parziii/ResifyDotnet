using System.ComponentModel.DataAnnotations;
using Resify.Services.ReservationAPI.Models.Enums;

namespace Resify.Services.ReservationAPI.Models;

public class Reservation
{
	[Key] public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public DateTime? CreatedAt { get; set; }
	public DateTime From { get; set; }
	public DateTime To { get; set; }
	public States State { get; set; }
	public int PeopleCount { get; set; }
	public Guid RestaurantId { get; set; }
}