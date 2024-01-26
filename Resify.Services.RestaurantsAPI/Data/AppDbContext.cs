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
		public DbSet<Tag> Tags { get; set; }
		public DbSet<FavoriteRestaurant> FavoriteRestaurants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Restaurant>().HasData(new Restaurant
			{
				Id = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				Name = "Włoska restauracja",
				Description = "TestowyOpis",
				City = "Kraków",
				Street = "Jagielońska 24",
				ZipCode = "12-345"
			});

			modelBuilder.Entity<Restaurant>().HasData(new Restaurant
			{
				Id = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				Name = "Amerykańska restauracja",
				Description = "TestowyOpis2",
				City = "Kraków",
				Street = "Jagielońska 13",
				ZipCode = "12-345"
			});

			modelBuilder.Entity<Tag>().HasData(new Tag
			{
				Id = new Guid("94596124-3883-466B-B632-C20FDF8A19BC"),
				Name = "American",
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC")
			});

			modelBuilder.Entity<Tag>().HasData(new Tag
			{
				Id = new Guid("94596123-3883-466B-B632-C20FDF8A19BC"),
				Name = "Italian",
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143")
			});
		}
	}
}
