using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class initDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 27, 13, 828, DateTimeKind.Local).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 27, 13, 828, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 27, 13, 828, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 27, 13, 828, DateTimeKind.Local).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4875));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4848));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 27, 13, 828, DateTimeKind.Utc).AddTicks(4831));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 6, 55, 296, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 6, 55, 296, DateTimeKind.Local).AddTicks(6782));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 6, 55, 296, DateTimeKind.Local).AddTicks(6783));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 6, 55, 296, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6873));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6884));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6886));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6892));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6856));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6836));
        }
    }
}
