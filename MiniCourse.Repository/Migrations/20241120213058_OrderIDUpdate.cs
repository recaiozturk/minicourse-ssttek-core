using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCourse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class OrderIDUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c697f0d5-f190-4770-aa29-2eb88a8a96d1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4aa9c832-807e-4b73-b9ea-a9bad944f9dd"), new Guid("a2bd55c7-509d-4466-9c57-94a45a3fec1c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4aa9c832-807e-4b73-b9ea-a9bad944f9dd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a2bd55c7-509d-4466-9c57-94a45a3fec1c"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("b149818b-4706-4612-b4b8-970d3e0d4ca1"), "b149818b-4706-4612-b4b8-970d3e0d4ca1", "User", "USER" },
                    { new Guid("c10f8800-7f91-4ea0-bf36-4b1a70b7ea8a"), "c10f8800-7f91-4ea0-bf36-4b1a70b7ea8a", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6e373459-d809-42eb-958c-766d48b7fe03"), 0, null, null, "96fdc9d1-8638-4a10-bd3f-5cca6e90e544", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEJvSXvN/Al73bW52IXDft/7/wRqUC0UEL2Wuo3PHVrPz/OMLeeW5RhtyeK/X67f1XA==", null, false, "0d1116fa-6e64-4c18-be22-500e5caeb8e8", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c10f8800-7f91-4ea0-bf36-4b1a70b7ea8a"), new Guid("6e373459-d809-42eb-958c-766d48b7fe03") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b149818b-4706-4612-b4b8-970d3e0d4ca1"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c10f8800-7f91-4ea0-bf36-4b1a70b7ea8a"), new Guid("6e373459-d809-42eb-958c-766d48b7fe03") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c10f8800-7f91-4ea0-bf36-4b1a70b7ea8a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6e373459-d809-42eb-958c-766d48b7fe03"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payments");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4aa9c832-807e-4b73-b9ea-a9bad944f9dd"), "4aa9c832-807e-4b73-b9ea-a9bad944f9dd", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("c697f0d5-f190-4770-aa29-2eb88a8a96d1"), "c697f0d5-f190-4770-aa29-2eb88a8a96d1", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a2bd55c7-509d-4466-9c57-94a45a3fec1c"), 0, null, null, "d1714d1c-4452-495e-9116-988a1d502930", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEEQvb+8+aXH7gPllKSu47K2h99g+cLxw81QC27U0GlLHGQn6e9Os97udLtmkY4W+BA==", null, false, "71669a3b-88e0-49bc-9dac-f62d0ed6ffca", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("4aa9c832-807e-4b73-b9ea-a9bad944f9dd"), new Guid("a2bd55c7-509d-4466-9c57-94a45a3fec1c") });
        }
    }
}
