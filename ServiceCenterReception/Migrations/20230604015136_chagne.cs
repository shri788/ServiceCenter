using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ServiceCenterReception.Migrations
{
    /// <inheritdoc />
    public partial class chagne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceTasksMasters");

            migrationBuilder.CreateTable(
                name: "serviceTaskMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaskName = table.Column<string>(type: "text", nullable: false),
                    TaskDescription = table.Column<string>(type: "text", nullable: false),
                    TaskCharges = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTaskMasters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceTaskMasters");

            migrationBuilder.CreateTable(
                name: "serviceTasksMasters",
                columns: table => new
                {
                    taskId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    chargesInRuppes = table.Column<long>(type: "bigint", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true),
                    taskServiceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceTasksMasters", x => x.taskId);
                });
        }
    }
}
