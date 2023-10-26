using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m1b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedIPV4Address",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "AddedTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "AddedUser",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedIPV4Address",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedUser",
                table: "UserRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedIPV4Address",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedTime",
                table: "UserRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "AddedUser",
                table: "UserRole",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedIPV4Address",
                table: "UserRole",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UpdatedUser",
                table: "UserRole",
                type: "bigint",
                nullable: true);
        }
    }
}
