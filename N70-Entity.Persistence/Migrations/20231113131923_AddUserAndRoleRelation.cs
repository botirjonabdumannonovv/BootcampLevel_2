using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N70_Entity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAndRoleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b375629-4f3f-4c23-806f-bd0f758ad683"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 19, 23, 324, DateTimeKind.Utc).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("45467824-7527-4530-a7fe-6d38dd09a3c5"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 19, 23, 324, DateTimeKind.Utc).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb05f885-807c-445a-aaff-673ee99f46f3"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 19, 23, 324, DateTimeKind.Utc).AddTicks(364));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b375629-4f3f-4c23-806f-bd0f758ad683"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 12, 58, 710, DateTimeKind.Utc).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("45467824-7527-4530-a7fe-6d38dd09a3c5"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 12, 58, 710, DateTimeKind.Utc).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fb05f885-807c-445a-aaff-673ee99f46f3"),
                column: "CreatedDate",
                value: new DateTime(2023, 11, 13, 13, 12, 58, 710, DateTimeKind.Utc).AddTicks(160));
        }
    }
}
