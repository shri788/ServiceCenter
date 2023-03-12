﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServiceCenterReception.Data;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    [DbContext(typeof(serviceCenterDbContext))]
    partial class serviceCenterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ServiceCenterReception.Entity.CustomerProfile", b =>
                {
                    b.Property<long>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("customerId"));

                    b.Property<DateTime>("DOB")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DOM")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<long>("addressPinCode")
                        .HasColumnType("bigint");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("dueInMonths")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("lastServiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("mobileNumber")
                        .HasColumnType("bigint");

                    b.HasKey("customerId");

                    b.ToTable("customerProfiles");
                });

            modelBuilder.Entity("ServiceCenterReception.Entity.VehicleDetails", b =>
                {
                    b.Property<long>("vehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("vehicleId"));

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.Property<string>("vehicleNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("vehicleType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("vehicleId");

                    b.HasIndex("customerId");

                    b.ToTable("vehicleDetails");
                });

            modelBuilder.Entity("ServiceCenterReception.Entity.VehicleServiceDetail", b =>
                {
                    b.Property<long>("vehicleServiceDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("vehicleServiceDetailId"));

                    b.Property<long?>("VehicleServiceRecieveDeliveryId")
                        .HasColumnType("bigint");

                    b.Property<long>("customerId")
                        .HasColumnType("bigint");

                    b.Property<long>("vehicleId")
                        .HasColumnType("bigint");

                    b.HasKey("vehicleServiceDetailId");

                    b.HasIndex("VehicleServiceRecieveDeliveryId");

                    b.HasIndex("customerId");

                    b.HasIndex("vehicleId");

                    b.ToTable("vehicleServiceDetails");
                });

            modelBuilder.Entity("ServiceCenterReception.Entity.VehicleServiceRecieveDelivery", b =>
                {
                    b.Property<long>("VehicleServiceRecieveDeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("VehicleServiceRecieveDeliveryId"));

                    b.Property<DateTime>("vehicleDeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("vehicleReceiveDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("VehicleServiceRecieveDeliveryId");

                    b.ToTable("vehicleServiceRecieveDeliveries");
                });

            modelBuilder.Entity("ServiceCenterReception.Entity.VehicleDetails", b =>
                {
                    b.HasOne("ServiceCenterReception.Entity.CustomerProfile", "CustomerProfile")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerProfile");
                });

            modelBuilder.Entity("ServiceCenterReception.Entity.VehicleServiceDetail", b =>
                {
                    b.HasOne("ServiceCenterReception.Entity.VehicleServiceRecieveDelivery", "VehicleServiceRecieveDelivery")
                        .WithMany()
                        .HasForeignKey("VehicleServiceRecieveDeliveryId");

                    b.HasOne("ServiceCenterReception.Entity.CustomerProfile", "CustomerProfile")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceCenterReception.Entity.VehicleDetails", "VehicleDetails")
                        .WithMany()
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerProfile");

                    b.Navigation("VehicleDetails");

                    b.Navigation("VehicleServiceRecieveDelivery");
                });
#pragma warning restore 612, 618
        }
    }
}
