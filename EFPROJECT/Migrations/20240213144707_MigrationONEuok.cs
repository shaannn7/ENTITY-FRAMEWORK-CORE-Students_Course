using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class MigrationONEuok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Teacher",
                table: "Courses",
                newName: "Mentor");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Courses",
                newName: "CourseName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mentor",
                table: "Courses",
                newName: "Teacher");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "Courses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");
        }
    }
}
