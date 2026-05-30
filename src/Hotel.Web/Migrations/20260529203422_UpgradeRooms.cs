using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Web.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Rooms",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "TEXT",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            _ = migrationBuilder.AddColumn<bool>(
                name: "HasBalcony",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<bool>(
                name: "HasPool",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<bool>(
                name: "HasWifi",
                table: "Rooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Rooms",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Rooms",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "HasBalcony",
                table: "Rooms");

            _ = migrationBuilder.DropColumn(
                name: "HasPool",
                table: "Rooms");

            _ = migrationBuilder.DropColumn(
                name: "HasWifi",
                table: "Rooms");

            _ = migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Rooms");

            _ = migrationBuilder.DropColumn(
                name: "Title",
                table: "Rooms");

            _ = migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Rooms",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 1000);
        }
    }
}
