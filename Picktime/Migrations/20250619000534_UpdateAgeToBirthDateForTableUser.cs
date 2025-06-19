using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAgeToBirthDateForTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Birthdate",
                table: "Users",
                type: "date",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 3, 5, 34, 282, DateTimeKind.Local).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 3, 5, 34, 282, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 3, 5, 34, 282, DateTimeKind.Local).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 3, 5, 34, 282, DateTimeKind.Local).AddTicks(8846));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9032));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9041));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9046));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "UserReviewServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9242));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthdate", "CreationDate" },
                values: new object[] { new DateOnly(2002, 4, 11), new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9071) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 19, 0, 5, 34, 282, DateTimeKind.Utc).AddTicks(9000));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Users");

            migrationBuilder.AddColumn<float>(
                name: "Age",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 49, 25, 994, DateTimeKind.Local).AddTicks(9035));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 49, 25, 994, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 49, 25, 994, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 22, 49, 25, 994, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9135));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "ProviderServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "UserReviewServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "CreationDate" },
                values: new object[] { 15f, new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9165) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9088));
        }
    }
}
