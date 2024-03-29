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
    [Migration("20240120212120_RemoveStreetNumber")]
    partial class RemoveStreetNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Name = "Restauracja1",
                            Street = "Jagielońska 24",
                            ZipCode = "12-345"
                        },
                        new
                        {
                            Id = new Guid("945969d0-3883-466b-b632-c20fdf8a19bc"),
                            City = "Kraków",
                            Description = "TestowyOpis2",
                            Name = "Restauracja2",
                            Street = "Jagielońska 13",
                            ZipCode = "12-345"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
