using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniCourse.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5e98e94-98a6-4b6f-9d17-ebc4fd70369c"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("46184609-7354-4c75-a147-57a585bcc693"), new Guid("945bc75c-cc6c-45c8-a79d-070c30ab0ecc") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46184609-7354-4c75-a147-57a585bcc693"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("945bc75c-cc6c-45c8-a79d-070c30ab0ecc"));

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "UpdatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("46184609-7354-4c75-a147-57a585bcc693"), "46184609-7354-4c75-a147-57a585bcc693", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f5e98e94-98a6-4b6f-9d17-ebc4fd70369c"), "f5e98e94-98a6-4b6f-9d17-ebc4fd70369c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adress", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("945bc75c-cc6c-45c8-a79d-070c30ab0ecc"), 0, null, null, "6d42f2b5-c9ec-4a2f-a5af-b346522df368", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEG20mfjXotLBR1uTPVPtoCDnHaCEfXI4aFYo0bq6CPuNFpfOjz1V4IlkwwmoxFZMEg==", null, false, "4e10fa9e-1ba7-4f22-a82d-faab7ba476c2", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("46184609-7354-4c75-a147-57a585bcc693"), new Guid("945bc75c-cc6c-45c8-a79d-070c30ab0ecc") });
        }
    }
}
