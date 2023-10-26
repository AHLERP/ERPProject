using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ERP1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "User",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "User",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "User",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "StockDetail",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "StockDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "StockDetail",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "StockDetail",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Stock",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Stock",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Stock",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Stock",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Role",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Role",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Role",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Role",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RequestDetail",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "RequestDetail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "RequestDetail",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "RequestDetail",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Request",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Request",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Request",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Request",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Product",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Product",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Product",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Offer",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Offer",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Offer",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Offer",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Invoice",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Invoice",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Invoice",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Invoice",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Department",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Department",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Department",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Department",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Company",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Company",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Company",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Company",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Category",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Category",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Category",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Category",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Brand",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Brand",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Brand",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Brand",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "User",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "User",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "User",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "StockDetail",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "StockDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "StockDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "StockDetail",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Stock",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Stock",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Stock",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Stock",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Role",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Role",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Role",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Role",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "RequestDetail",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "RequestDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "RequestDetail",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "RequestDetail",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Request",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Request",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Request",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Request",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Product",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Product",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Offer",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Offer",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Offer",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Offer",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Invoice",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Invoice",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Invoice",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Invoice",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Department",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Department",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Department",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Company",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Company",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Company",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Category",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Category",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Category",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Brand",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AddedUser",
                table: "Brand",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedTime",
                table: "Brand",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedIP4VAdress",
                table: "Brand",
                type: "char(15)",
                unicode: false,
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(15)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 15,
                oldNullable: true);
        }
    }
}
