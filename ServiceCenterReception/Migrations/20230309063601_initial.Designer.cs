// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ServiceCenterReception.Data;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    [DbContext(typeof(serviceCenterDbContext))]
    [Migration("20230309063601_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}
