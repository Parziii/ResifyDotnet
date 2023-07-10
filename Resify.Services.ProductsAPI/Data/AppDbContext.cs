using Microsoft.EntityFrameworkCore;
using Resify.Services.ProductsAPI.Models;

namespace Resify.Services.ProductsAPI.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var categoryId1 = Guid.NewGuid();
			var categoryId2 = Guid.NewGuid();
			var categoryId3 = Guid.NewGuid();

			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = categoryId1,
				Name = "Włoskie"
			});

			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = categoryId2,
				Name = "Polskie"
			});

			modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory
			{
				Id = categoryId3,
				Name = "Amerykańskie"
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				ProductCategoryId = categoryId1,
				Name = "Pizza",
				Price = 13.12m,
				ImageUrl = "nic"
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				ProductCategoryId = categoryId1,
				Name = "Spaghetti",
				Price = 23.50m,
				ImageUrl = "nic"
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("5141148D-2D80-4C88-ACE3-606EC8583143"),
				ProductCategoryId = categoryId2,
				Name = "Pierogi",
				Price = 30.50m,
				ImageUrl = "nic"
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				ProductCategoryId = categoryId3,
				Name = "Hamburger",
				Price = 38.50m,
				ImageUrl = "nic"
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				ProductCategoryId = categoryId3,
				Name = "Frytki",
				Price = 8.99m,
				ImageUrl = "nic"
			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = Guid.NewGuid(),
				RestaurantId = new Guid("945969D0-3883-466B-B632-C20FDF8A19BC"),
				ProductCategoryId = categoryId3,
				Name = "Pizza",
				Price = 45m,
				ImageUrl = "nic"
			});

			
		}
	}
}
