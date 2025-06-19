using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Picktime.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LockUpType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockUpType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<float>(type: "real", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedLanguage = table.Column<int>(type: "int", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    LastLoggedInDeviceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVerfied = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OTPCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTPExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LockUpItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    LockUpTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LockUpItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LockUpItems_LockUpType_LockUpTypeId",
                        column: x => x.LockUpTypeId,
                        principalTable: "LockUpType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
                    ServiceProvidersId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedEstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ActualEstimatedTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedArrivalTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketNumber = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ServicesEntityId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_ServicesEntities_ServicesEntityId",
                        column: x => x.ServicesEntityId,
                        principalTable: "ServicesEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LockUpType",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsActive", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "System", new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2633), true, "Coupon", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName", "CreatedBy", "CreationDate", "Icon", "IsActive", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, "Bank", "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2773), "fa-solid fa-building-columns", true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "LockUpItems",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "Discount", "IsActive", "LockUpTypeId", "Points", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2751), 0.1f, true, 1, 100, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "System", new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2754), 0.2f, true, 1, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "System", new DateTime(2025, 6, 18, 21, 21, 2, 807, DateTimeKind.Local).AddTicks(2755), 0.3f, true, 1, 300, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "CreationDate", "Description", "IsActive", "Logo", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 1, "Seed", new DateTime(2025, 6, 18, 18, 21, 2, 807, DateTimeKind.Utc).AddTicks(2789), "Arab Bank", true, "fa-solid fa-kaaba", "Arab Bank", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServicesEntityId",
                table: "Bookings",
                column: "ServicesEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UsersId",
                table: "Bookings",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_LockUpItems_LockUpTypeId",
                table: "LockUpItems",
                column: "LockUpTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CategoryId",
                table: "Providers",
                column: "CategoryId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "LockUpItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ServicesEntities");

            migrationBuilder.DropTable(
                name: "LockUpType");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
