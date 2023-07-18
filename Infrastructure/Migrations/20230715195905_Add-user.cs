using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName" },
                values: new object[] { 10, 0, "58266a6e-6d15-4e5a-b8f4-1ccf79a8eeec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sakrmahmoud21@gmail.com", true, false, null, null, null, "Mahmoud@1234", null, false, "DC21D266-C24A-4676-BDAE-345D0EE14766", false, null, null, "MahmoudSakr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
