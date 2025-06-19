using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class initDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UsersId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviewServices_Users_UsersId",
                table: "UserReviewServices");

            migrationBuilder.DropIndex(
                name: "IX_UserReviewServices_UsersId",
                table: "UserReviewServices");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UsersId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UserReviewServices");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "LastLoggedInDeviceAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsVerfied",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "CreatedBy", "CreationDate", "Email", "FirstName", "Gender", "IsActive", "IsAdmin", "IsLoggedIn", "IsVerfied", "LastLoggedInDeviceAddress", "LastLoginTime", "LastName", "OTPCode", "OTPExpiry", "Password", "PhoneNumber", "Points", "SelectedLanguage", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 15f, "Seed", new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9165), "Seed@PicTime.com", "seed", "Robo", true, true, false, null, null, null, "Root", null, null, "0000000000", "07777777777", 0, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9088));

            migrationBuilder.InsertData(
                table: "UserReviewServices",
                columns: new[] { "Id", "Comment", "CreatedBy", "CreationDate", "IsActive", "ProviderId", "ProviderServiceId", "Rate", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, "From Seed", "Seed", new DateTime(2025, 6, 18, 19, 49, 25, 994, DateTimeKind.Utc).AddTicks(9189), true, null, 1, 2f, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewServices_UserId",
                table: "UserReviewServices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviewServices_Users_UserId",
                table: "UserReviewServices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviewServices_Users_UserId",
                table: "UserReviewServices");

            migrationBuilder.DropIndex(
                name: "IX_UserReviewServices_UserId",
                table: "UserReviewServices");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "UserReviewServices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastLoggedInDeviceAddress",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsVerfied",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UserReviewServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewServices_UsersId",
                table: "UserReviewServices",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UsersId",
                table: "Bookings",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UsersId",
                table: "Bookings",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviewServices_Users_UsersId",
                table: "UserReviewServices",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
