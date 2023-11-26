using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holy_locket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Inactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Appointments",
                newName: "Inactive");

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Specialities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Hospitals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<bool>(
                name: "Inactive",
                table: "Doctors",
                type: "bit",
                maxLength: 15,
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Inactive",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "Inactive",
                table: "Appointments",
                newName: "IsActive");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Doctors",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
