using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    /// <inheritdoc />
    public partial class task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "customerId",
                table: "vehicleServiceTaskCompletedLists",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerId",
                table: "vehicleServiceTaskCompletedLists");
        }
    }
}
