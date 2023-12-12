using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holy_locket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RatingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Ratings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Ratings");
        }
    }
}
