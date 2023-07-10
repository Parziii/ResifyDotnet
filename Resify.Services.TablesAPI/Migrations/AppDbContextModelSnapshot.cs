﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resify.Services.TablesAPI.Data;

#nullable disable

namespace Resify.Services.TablesAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Resify.Services.TablesAPI.Models.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChairCount")
                        .HasColumnType("int");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ea9b405b-7de6-4580-88e7-b340525f6871"),
                            Category = "Pod oknem",
                            ChairCount = 3,
                            RestaurantId = new Guid("5141148d-2d80-4c88-ace3-606ec8583143")
                        },
                        new
                        {
                            Id = new Guid("bf2d1c10-90a1-48c7-8645-9d8a2d35ea07"),
                            Category = "W środku",
                            ChairCount = 5,
                            RestaurantId = new Guid("5141148d-2d80-4c88-ace3-606ec8583143")
                        },
                        new
                        {
                            Id = new Guid("1b0878b6-3f49-4c30-9d50-c0a4d7c2ad3a"),
                            Category = "Pod oknem",
                            ChairCount = 2,
                            RestaurantId = new Guid("5141148d-2d80-4c88-ace3-606ec8583143")
                        },
                        new
                        {
                            Id = new Guid("a3577c63-d6ea-44e1-9663-d2d63a982dfa"),
                            Category = "Pod oknem",
                            ChairCount = 3,
                            RestaurantId = new Guid("945969d0-3883-466b-b632-c20fdf8a19bc")
                        },
                        new
                        {
                            Id = new Guid("83f23167-4ba7-42d0-9824-f67d87f692b7"),
                            Category = "W środku",
                            ChairCount = 5,
                            RestaurantId = new Guid("945969d0-3883-466b-b632-c20fdf8a19bc")
                        },
                        new
                        {
                            Id = new Guid("07a3695e-142d-464a-9159-8b0d527bcf2b"),
                            Category = "Pod oknem",
                            ChairCount = 2,
                            RestaurantId = new Guid("945969d0-3883-466b-b632-c20fdf8a19bc")
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
