using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    /// <inheritdoc />
    public partial class masteradd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "vehicleServiceTaskCompletedLists",
                columns: table => new
                {
                    taskServiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    taskServiceName = table.Column<string>(type: "text", nullable: false),
                    taskServiceCharges = table.Column<long>(type: "bigint", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true),
                    vehicleServiceDetailId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleServiceTaskCompletedLists", x => x.taskServiceId);
                    table.ForeignKey(
                        name: "FK_vehicleServiceTaskCompletedLists_vehicleServiceDetails_vehi~",
                        column: x => x.vehicleServiceDetailId,
                        principalTable: "vehicleServiceDetails",
                        principalColumn: "vehicleServiceDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vehicleServiceTaskCompletedLists_vehicleServiceDetailId",
                table: "vehicleServiceTaskCompletedLists",
                column: "vehicleServiceDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceTasksMasters");

            migrationBuilder.DropTable(
                name: "vehicleServiceTaskCompletedLists");
        }
    }
}
