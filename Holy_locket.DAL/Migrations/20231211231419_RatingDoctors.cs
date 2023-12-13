using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holy_locket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RatingDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Doctors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Doctors");
        }
    }
}
