using Microsoft.EntityFrameworkCore;
using Resify.Services.ReservationAPI.Models;

namespace Resify.Services.ReservationAPI.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	public DbSet<Reservation> Reservations { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}