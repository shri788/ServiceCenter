using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerProfiles",
                columns: table => new
                {
                    customerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    gender = table.Column<string>(type: "text", nullable: false),
                    customerName = table.Column<string>(type: "text", nullable: false),
                    mobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    addressPinCode = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DOM = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    lastServiceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dueInMonths = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerProfiles", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "finalServiceBills",
                columns: table => new
                {
                    finalServiceBillId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerId = table.Column<long>(type: "bigint", nullable: false),
                    vehicleServiceDetailId = table.Column<long>(type: "bigint", nullable: false),
                    totalAmount = table.Column<long>(type: "bigint", nullable: false),
                    discountPercentage = table.Column<long>(type: "bigint", nullable: false),
                    discountAmount = table.Column<long>(type: "bigint", nullable: false),
                    amountPaid = table.Column<long>(type: "bigint", nullable: false),
                    dateTimeGenerated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finalServiceBills", x => x.finalServiceBillId);
                });

            migrationBuilder.CreateTable(
                name: "serviceTasksMasters",
                columns: table => new
                {
                    taskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    taskServiceName = table.Column<string>(type: "text", nullable: false),
                    chargesInRuppes = table.Column<long>(type: "bigint", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTasksMasters", x => x.taskId);
                });

            migrationBuilder.CreateTable(
                name: "vehicleServiceRecieveDeliveries",
                columns: table => new
                {
                    VehicleServiceRecieveDeliveryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vehicleReceiveDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    vehicleDeliveryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleServiceRecieveDeliveries", x => x.VehicleServiceRecieveDeliveryId);
                });

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
                        name: "FK_vehicleServiceDetails_vehicleServiceRecieveDeliveries_Vehic~",
                        column: x => x.VehicleServiceRecieveDeliveryId,
                        principalTable: "vehicleServiceRecieveDeliveries",
                        principalColumn: "VehicleServiceRecieveDeliveryId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCompletedTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Task = table.Column<string>(type: "text", nullable: false),
                    TaskDescription = table.Column<string>(type: "text", nullable: true),
                    TaskCharges = table.Column<int>(type: "integer", nullable: false),
                    vehicleServiceDetailId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCompletedTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCompletedTask_vehicleServiceDetails_vehicleServiceDe~",
                        column: x => x.vehicleServiceDetailId,
                        principalTable: "vehicleServiceDetails",
                        principalColumn: "vehicleServiceDetailId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceEstimationTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Task = table.Column<string>(type: "text", nullable: false),
                    TaskDescription = table.Column<string>(type: "text", nullable: true),
                    EstimatedAmount = table.Column<int>(type: "integer", nullable: false),
                    vehicleServiceDetailId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceEstimationTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceEstimationTask_vehicleServiceDetails_vehicleServiceD~",
                        column: x => x.vehicleServiceDetailId,
                        principalTable: "vehicleServiceDetails",
                        principalColumn: "vehicleServiceDetailId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customerProfiles_mobileNumber",
                table: "customerProfiles",
                column: "mobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCompletedTask_vehicleServiceDetailId",
                table: "ServiceCompletedTask",
                column: "vehicleServiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceEstimationTask_vehicleServiceDetailId",
                table: "ServiceEstimationTask",
                column: "vehicleServiceDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleDetails_customerId",
                table: "vehicleDetails",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleServiceDetails_customerId",
                table: "vehicleServiceDetails",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleServiceDetails_VehicleServiceRecieveDeliveryId",
                table: "vehicleServiceDetails",
                column: "VehicleServiceRecieveDeliveryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "finalServiceBills");

            migrationBuilder.DropTable(
                name: "ServiceCompletedTask");

            migrationBuilder.DropTable(
                name: "ServiceEstimationTask");

            migrationBuilder.DropTable(
                name: "serviceTasksMasters");

            migrationBuilder.DropTable(
                name: "vehicleDetails");

            migrationBuilder.DropTable(
                name: "vehicleServiceDetails");

            migrationBuilder.DropTable(
                name: "customerProfiles");

            migrationBuilder.DropTable(
                name: "vehicleServiceRecieveDeliveries");
        }
    }
}
