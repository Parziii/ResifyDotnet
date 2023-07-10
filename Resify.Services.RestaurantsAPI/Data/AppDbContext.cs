using Microsoft.EntityFrameworkCore;
using Resify.Services.RestaurantsAPI.Models;

namespace Resify.Services.RestaurantsAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Restaurant> Restaurants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Restaurant>().HasData(new Restaurant
			{
				Id = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				Name = "Restauracja1",
				Description = "TestowyOpis",
				City = "Kraków",
				Street = "Jagielońska",
				StreetNumber = "30",
				ZipCode = "12-345"
			});

			modelBuilder.Entity<Restaurant>().HasData(new Restaurant
			{
				Id = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				Name = "Restauracja2",
				Description = "TestowyOpis2",
				City = "Kraków",
				Street = "Jagielońska",
				StreetNumber = "31",
				ZipCode = "12-345"
			});
		}
	}
}
