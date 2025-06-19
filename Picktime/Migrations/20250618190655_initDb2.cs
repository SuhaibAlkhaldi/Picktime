using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class initDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ServicesEntities_ServicesEntityId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ServicesEntities");

            migrationBuilder.CreateTable(
                name: "ProviderServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedEstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ActualEstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProviderServices_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReviewServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    ProviderServiceId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReviewServices_ProviderServices_ProviderServiceId",
                        column: x => x.ProviderServiceId,
                        principalTable: "ProviderServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewServices_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserReviewServices_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "ProviderServices",
                columns: new[] { "Id", "ActualEstimatedTime", "CreatedBy", "CreationDate", "Description", "ExpectedEstimatedTime", "IsActive", "Name", "ProviderId", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new TimeOnly(0, 1, 30), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6873), "Service Time 1m ", new TimeOnly(0, 1, 0), true, "1M Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new TimeOnly(0, 2, 0), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6880), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6882), "Service Time 1m ", new TimeOnly(0, 1, 0), true, "1m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new TimeOnly(0, 1, 30), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6884), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6886), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6890), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6892), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 19, 6, 55, 296, DateTimeKind.Utc).AddTicks(6894), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProviderServices_ProviderId",
                table: "ProviderServices",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewServices_ProviderId",
                table: "UserReviewServices",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewServices_ProviderServiceId",
                table: "UserReviewServices",
                column: "ProviderServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewServices_UsersId",
                table: "UserReviewServices",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ProviderServices_ServicesEntityId",
                table: "Bookings",
                column: "ServicesEntityId",
                principalTable: "ProviderServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_ProviderServices_ServicesEntityId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "UserReviewServices");

            migrationBuilder.DropTable(
                name: "ProviderServices");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProvidersId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Providers_ServiceProvidersId",
                        column: x => x.ServiceProvidersId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    ActualEstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedEstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesEntities_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "LockUpItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "LockUpType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2633));

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.InsertData(
                table: "ServicesEntities",
                columns: new[] { "Id", "ActualEstimatedTime", "CreatedBy", "CreationDate", "Description", "ExpectedEstimatedTime", "IsActive", "Name", "ProviderId", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new TimeOnly(0, 1, 30), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2805), "Service Time 1m ", new TimeOnly(0, 1, 0), true, "1M Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new TimeOnly(0, 2, 0), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2811), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2813), "Service Time 1m ", new TimeOnly(0, 1, 0), true, "1m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new TimeOnly(0, 1, 30), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2815), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2817), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2819), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2821), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 0, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new TimeOnly(0, 1, 0), "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2823), "Service Time 2m ", new TimeOnly(0, 2, 0), true, "2m Service", 1, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2773));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceProvidersId",
                table: "Reviews",
                column: "ServiceProvidersId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UsersId",
                table: "Reviews",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesEntities_ProviderId",
                table: "ServicesEntities",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_ServicesEntities_ServicesEntityId",
                table: "Bookings",
                column: "ServicesEntityId",
                principalTable: "ServicesEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
