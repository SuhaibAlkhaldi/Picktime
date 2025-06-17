using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_ServicesId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "OTPExipry",
                table: "Users",
                newName: "OTPExpiry");

            migrationBuilder.RenameColumn(
                name: "IsLogedIn",
                table: "Users",
                newName: "IsLoggedIn");

            migrationBuilder.RenameColumn(
                name: "ServicesId",
                table: "Bookings",
                newName: "ServicesEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ServicesId",
                table: "Bookings",
                newName: "IX_Bookings_ServicesEntityId");

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 22, 15, 58, 684, DateTimeKind.Local).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 22, 15, 58, 684, DateTimeKind.Local).AddTicks(9947));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 22, 15, 58, 684, DateTimeKind.Local).AddTicks(9948));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 22, 15, 58, 684, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Services_ServicesEntityId",
                table: "Bookings",
                column: "ServicesEntityId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_ServicesEntityId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "OTPExpiry",
                table: "Users",
                newName: "OTPExipry");

            migrationBuilder.RenameColumn(
                name: "IsLoggedIn",
                table: "Users",
                newName: "IsLogedIn");

            migrationBuilder.RenameColumn(
                name: "ServicesEntityId",
                table: "Bookings",
                newName: "ServicesId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ServicesEntityId",
                table: "Bookings",
                newName: "IX_Bookings_ServicesId");

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 19, 8, 22, 529, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 19, 8, 22, 529, DateTimeKind.Local).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 19, 8, 22, 529, DateTimeKind.Local).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 17, 19, 8, 22, 529, DateTimeKind.Local).AddTicks(4988));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Services_ServicesId",
                table: "Bookings",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
