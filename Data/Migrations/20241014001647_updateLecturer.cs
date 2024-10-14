using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace St10375622Part2.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateLecturer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LecturerName",
                table: "Lecturers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Lecturers",
                newName: "LecturerName");
        }
    }
}
