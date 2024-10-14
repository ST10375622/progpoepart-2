using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace St10375622Part2.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdminUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicManager",
                columns: table => new
                {
                    AcademicManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicManager", x => x.AcademicManagerId);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeCoordinator",
                columns: table => new
                {
                    ProgrammeCoordinatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeCoordinator", x => x.ProgrammeCoordinatorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicManager");

            migrationBuilder.DropTable(
                name: "ProgrammeCoordinator");
        }
    }
}
