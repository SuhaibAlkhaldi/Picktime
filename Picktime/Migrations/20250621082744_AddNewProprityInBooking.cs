using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProprityInBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 11, 27, 43, 370, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 11, 27, 43, 370, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 11, 27, 43, 370, DateTimeKind.Local).AddTicks(8701));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 11, 27, 43, 370, DateTimeKind.Local).AddTicks(8512));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8800));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8803));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8806));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8811));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8814));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8760));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 21, 8, 27, 43, 370, DateTimeKind.Utc).AddTicks(8730));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 19, 37, 10, 377, DateTimeKind.Local).AddTicks(1597));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 19, 37, 10, 377, DateTimeKind.Local).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 19, 37, 10, 377, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 19, 37, 10, 377, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1706));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 20, 16, 37, 10, 377, DateTimeKind.Utc).AddTicks(1638));
        }
    }
}
