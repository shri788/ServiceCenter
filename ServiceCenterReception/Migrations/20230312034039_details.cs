using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    /// <inheritdoc />
    public partial class details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicleDetails",
                columns: table => new
                {
                    vehicleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicleType = table.Column<string>(type: "text", nullable: false),
                    vehicleNumber = table.Column<string>(type: "text", nullable: false),
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleDetails", x => x.vehicleId);
                    table.ForeignKey(
                        name: "FK_vehicleDetails_customerProfiles_customerId",
                        column: x => x.customerId,
                        principalTable: "customerProfiles",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleServiceRecieveDeliveries",
                columns: table => new
                {
                    VehicleServiceRecieveDeliveryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicleReceiveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vehicleDeliveryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleServiceRecieveDeliveries", x => x.VehicleServiceRecieveDeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "vehicleServiceDetails",
                columns: table => new
                {
                    vehicleServiceDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicleId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleServiceRecieveDeliveryId = table.Column<long>(type: "bigint", nullable: true),
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleServiceDetails", x => x.vehicleServiceDetailId);
                    table.ForeignKey(
                        name: "FK_vehicleServiceDetails_customerProfiles_customerId",
                        column: x => x.customerId,
                        principalTable: "customerProfiles",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicleServiceDetails_vehicleDetails_vehicleId",
                        column: x => x.vehicleId,
                        principalTable: "vehicleDetails",
                        principalColumn: "vehicleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicleServiceDetails_vehicleServiceRecieveDeliveries_Vehic~",
                        column: x => x.VehicleServiceRecieveDeliveryId,
                        principalTable: "vehicleServiceRecieveDeliveries",
                        principalColumn: "VehicleServiceRecieveDeliveryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicleDetails_customerId",
                table: "vehicleDetails",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleServiceDetails_customerId",
                table: "vehicleServiceDetails",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleServiceDetails_vehicleId",
                table: "vehicleServiceDetails",
                column: "vehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleServiceDetails_VehicleServiceRecieveDeliveryId",
                table: "vehicleServiceDetails",
                column: "VehicleServiceRecieveDeliveryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicleServiceDetails");

            migrationBuilder.DropTable(
                name: "vehicleDetails");

            migrationBuilder.DropTable(
                name: "vehicleServiceRecieveDeliveries");
        }
    }
}
