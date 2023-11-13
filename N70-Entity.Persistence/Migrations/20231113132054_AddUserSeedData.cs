using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N70_Entity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b375629-4f3f-4c23-806f-bd0f758ad683"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 20, 54, 740, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("45467824-7527-4530-a7fe-6d38dd09a3c5"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 20, 54, 740, DateTimeKind.Utc).AddTicks(806));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb05f885-807c-445a-aaff-673ee99f46f3"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 20, 54, 740, DateTimeKind.Utc).AddTicks(811));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b375629-4f3f-4c23-806f-bd0f758ad683"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 20, 4, 233, DateTimeKind.Utc).AddTicks(744));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("45467824-7527-4530-a7fe-6d38dd09a3c5"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 20, 4, 233, DateTimeKind.Utc).AddTicks(736));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb05f885-807c-445a-aaff-673ee99f46f3"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 20, 4, 233, DateTimeKind.Utc).AddTicks(741));
        }
    }
}
