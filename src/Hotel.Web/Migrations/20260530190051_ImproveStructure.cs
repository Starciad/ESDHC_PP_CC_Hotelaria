using Microsoft.EntityFrameworkCore.Migrations;

using System;

#nullable disable

namespace Hotel.Web.Migrations
{
    /// <inheritdoc />
    public partial class ImproveStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Employees_EmployeeId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Guests_GuestId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Reserves_ReserveId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Rooms_RoomId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Payments_Flows_FlowId",
                table: "Payments");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Guests_GuestId",
                table: "Reserves");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Rooms_RoomId",
                table: "Reserves");

            _ = migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Rooms",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500,
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Reserves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "Reserves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "FlowId",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Guests",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Guests",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Flows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "ReserveId",
                table: "Flows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "Flows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Flows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Employees",
                type: "TEXT",
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            _ = migrationBuilder.AddColumn<DateTime>(
                name: "BirthdayDate",
                table: "Dependents",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            _ = migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Dependents",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Dependents",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            _ = migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Dependents_GuestId",
                table: "Dependents",
                column: "GuestId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Dependents_Guests_GuestId",
                table: "Dependents",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Employees_EmployeeId",
                table: "Flows",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Guests_GuestId",
                table: "Flows",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Reserves_ReserveId",
                table: "Flows",
                column: "ReserveId",
                principalTable: "Reserves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Rooms_RoomId",
                table: "Flows",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Payments_Flows_FlowId",
                table: "Payments",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Guests_GuestId",
                table: "Reserves",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Rooms_RoomId",
                table: "Reserves",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Dependents_Guests_GuestId",
                table: "Dependents");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Employees_EmployeeId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Guests_GuestId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Reserves_ReserveId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Flows_Rooms_RoomId",
                table: "Flows");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Payments_Flows_FlowId",
                table: "Payments");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Guests_GuestId",
                table: "Reserves");

            _ = migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Rooms_RoomId",
                table: "Reserves");

            _ = migrationBuilder.DropIndex(
                name: "IX_Dependents_GuestId",
                table: "Dependents");

            _ = migrationBuilder.DropColumn(
                name: "BirthdayDate",
                table: "Dependents");

            _ = migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Dependents");

            _ = migrationBuilder.DropColumn(
                name: "Name",
                table: "Dependents");

            _ = migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Rooms",
                type: "TEXT",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 500);

            _ = migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Reserves",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "Reserves",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<int>(
                name: "FlowId",
                table: "Payments",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Guests",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            _ = migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Guests",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            _ = migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Flows",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<int>(
                name: "ReserveId",
                table: "Flows",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<int>(
                name: "GuestId",
                table: "Flows",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Flows",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 255);

            _ = migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 14);

            _ = migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Employees_EmployeeId",
                table: "Flows",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Guests_GuestId",
                table: "Flows",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Reserves_ReserveId",
                table: "Flows",
                column: "ReserveId",
                principalTable: "Reserves",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Flows_Rooms_RoomId",
                table: "Flows",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Payments_Flows_FlowId",
                table: "Payments",
                column: "FlowId",
                principalTable: "Flows",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Guests_GuestId",
                table: "Reserves",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Rooms_RoomId",
                table: "Reserves",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
