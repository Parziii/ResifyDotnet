﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resify.Services.ReservationAPI.Data;

#nullable disable

namespace Resify.Services.ReservationAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230704195953_InitialAdd")]
    partial class InitialAdd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Resify.Services.ReservationAPI.Models.OrderDetails", b =>
                {
                    b.Property<Guid>("OrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservationDetailsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OrderDetailsId");

                    b.HasIndex("ReservationDetailsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Resify.Services.ReservationAPI.Models.ReservationDetails", b =>
                {
                    b.Property<Guid>("ReservationDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReservationHeaderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReservationDetailId");

                    b.HasIndex("ReservationHeaderId");

                    b.ToTable("ReservationDetails");
                });

            modelBuilder.Entity("Resify.Services.ReservationAPI.Models.ReservationHeader", b =>
                {
                    b.Property<Guid>("ReservationHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StarTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationHeaderId");

                    b.ToTable("ReservationHeaders");
                });

            modelBuilder.Entity("Resify.Services.ReservationAPI.Models.OrderDetails", b =>
                {
                    b.HasOne("Resify.Services.ReservationAPI.Models.ReservationDetails", "ReservationDetails")
                        .WithMany()
                        .HasForeignKey("ReservationDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservationDetails");
                });

            modelBuilder.Entity("Resify.Services.ReservationAPI.Models.ReservationDetails", b =>
                {
                    b.HasOne("Resify.Services.ReservationAPI.Models.ReservationHeader", "ReservationHeader")
                        .WithMany()
                        .HasForeignKey("ReservationHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReservationHeader");
                });
#pragma warning restore 612, 618
        }
    }
}
