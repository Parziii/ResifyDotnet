﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resify.Services.RestaurantsAPI.Data;

#nullable disable

namespace Resify.Services.RestaurantsAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240121145320_ModifyFavorite")]
    partial class ModifyFavorite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Resify.Services.RestaurantsAPI.Models.FavoriteRestaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("FavoriteRestaurants");
                });

            modelBuilder.Entity("Resify.Services.RestaurantsAPI.Models.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5141148d-2d80-4c88-ace3-606ec8583143"),
                            City = "Kraków",
                            Description = "TestowyOpis",
                            Name = "Włoska restauracja",
                            Street = "Jagielońska 24",
                            ZipCode = "12-345"
                        },
                        new
                        {
                            Id = new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"),
                            City = "Kraków",
                            Description = "TestowyOpis2",
                            Name = "Amerykańska restauracja",
                            Street = "Jagielońska 13",
                            ZipCode = "12-345"
                        });
                });

            modelBuilder.Entity("Resify.Services.RestaurantsAPI.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("94596124-3883-466b-b632-c20fdf8a19bc"),
                            Name = "American",
                            RestaurantId = new Guid("945969d0-3883-466b-b632-c20fdf8a19bc")
                        },
                        new
                        {
                            Id = new Guid("94596123-3883-466b-b632-c20fdf8a19bc"),
                            Name = "Italian",
                            RestaurantId = new Guid("5141148d-2d80-4c88-ace3-606ec8583143")
                        });
                });

            modelBuilder.Entity("Resify.Services.RestaurantsAPI.Models.FavoriteRestaurant", b =>
                {
                    b.HasOne("Resify.Services.RestaurantsAPI.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Resify.Services.RestaurantsAPI.Models.Tag", b =>
                {
                    b.HasOne("Resify.Services.RestaurantsAPI.Models.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}
