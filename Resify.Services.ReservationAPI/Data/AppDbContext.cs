using Microsoft.EntityFrameworkCore;
using Resify.Services.ReservationAPI.Models;

namespace Resify.Services.ReservationAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<ReservationDetails> ReservationDetails { get; set; }
		public DbSet<ReservationHeader> ReservationHeaders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
