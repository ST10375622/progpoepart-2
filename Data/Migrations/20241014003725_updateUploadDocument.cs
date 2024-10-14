using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace St10375622Part2.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateUploadDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Lecturers_LecturerId1",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_LecturerId1",
                table: "File");

            migrationBuilder.DropColumn(
                name: "LecturerId1",
                table: "File");

            migrationBuilder.AlterColumn<int>(
                name: "LecturerId",
                table: "File",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_LecturerId",
                table: "File",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Lecturers_LecturerId",
                table: "File",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "LecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Lecturers_LecturerId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_LecturerId",
                table: "File");

            migrationBuilder.AlterColumn<string>(
                name: "LecturerId",
                table: "File",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LecturerId1",
                table: "File",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_File_LecturerId1",
                table: "File",
                column: "LecturerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_File_Lecturers_LecturerId1",
                table: "File",
                column: "LecturerId1",
                principalTable: "Lecturers",
                principalColumn: "LecturerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
