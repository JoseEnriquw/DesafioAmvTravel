using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destiny = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Client = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "booking_tourId_fk",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tour",
                columns: new[] { "Id", "Destiny", "EndDate", "Name", "Price", "StartDate" },
                values: new object[,]
                {
                    { 1, "City A", new DateTime(2024, 3, 23, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2640), "Tour A", 1000m, new DateTime(2024, 3, 16, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2638) },
                    { 2, "City B", new DateTime(2024, 4, 6, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2644), "Tour B", 1200m, new DateTime(2024, 3, 30, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2643) },
                    { 3, "City C", new DateTime(2024, 4, 15, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2645), "Tour C", 800.25m, new DateTime(2024, 4, 8, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2645) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "Email", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@gmail.com", "User 1" },
                    { 2, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@gmail.com", "User 2" },
                    { 3, new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@gmail.com", "User 3" },
                    { 4, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@gmail.com", "User 4" }
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "BookingDate", "Client", "TourId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 9, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2008), "Cliente1", 1 },
                    { 2, new DateTime(2024, 3, 10, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2016), "Cliente2", 2 },
                    { 3, new DateTime(2024, 3, 11, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2021), "Cliente3", 3 },
                    { 4, new DateTime(2024, 3, 11, 10, 46, 51, 224, DateTimeKind.Local).AddTicks(2022), "Cliente4", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TourId",
                table: "Booking",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
