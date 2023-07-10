using Microsoft.EntityFrameworkCore;
using Resify.Services.TablesAPI.Models;

namespace Resify.Services.TablesAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Table> Tables { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Table>().HasData(new Table
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				Category = "Pod oknem",
				ChairCount = 3
			});

			modelBuilder.Entity<Table>().HasData(new Table
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				Category = "W środku",
				ChairCount = 5
			});

			modelBuilder.Entity<Table>().HasData(new Table
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				Category = "Pod oknem",
				ChairCount = 2
			});

			modelBuilder.Entity<Table>().HasData(new Table
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				Category = "Pod oknem",
				ChairCount = 3
			});

			modelBuilder.Entity<Table>().HasData(new Table
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				Category = "W środku",
				ChairCount = 5
			});

			modelBuilder.Entity<Table>().HasData(new Table
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				Category = "Pod oknem",
				ChairCount = 2
			});
		}
	}
}
