using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API1._0.Migrations
{
    /// <inheritdoc />
    public partial class createsemestertable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "No",
                table: "Semester",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Semester");
        }
    }
}
