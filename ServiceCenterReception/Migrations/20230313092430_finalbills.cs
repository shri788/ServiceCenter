using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    /// <inheritdoc />
    public partial class finalbills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    dateTimeGenerated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finalServiceBills", x => x.finalServiceBillId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "finalServiceBills");
        }
    }
}
