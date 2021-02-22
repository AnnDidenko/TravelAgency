using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DALnew.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    DeparturePlace = table.Column<string>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sum = table.Column<decimal>(nullable: false),
                    PhoneNumer = table.Column<string>(nullable: true),
                    TourId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Amount", "Category", "Country", "DepartureDate", "DeparturePlace", "Duration", "Price" },
                values: new object[,]
                {
                    { 1, 10, "sightseeing", "Germany", new DateTime(2020, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), "Kiev", 5, 5000 },
                    { 2, 5, "burning", "Turkey", new DateTime(2020, 6, 20, 12, 30, 0, 0, DateTimeKind.Unspecified), "Kiev", 10, 7000 },
                    { 3, 17, "sightseeing", "Georgia", new DateTime(2020, 9, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), "Kiev", 5, 5000 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Password", "PhoneNumber", "Role", "Surname", "Username" },
                values: new object[] { 1, 19, "ann.didenko8@gmail.com", "Ann", "10000.5SaZ0kE5nup5hhOCEnuVAA==.YlxU3SSYI/RNCvopTIH5VDFtzMVf4oKOb93G0dNVhX0=", "0508116770", "admin", "Didenko", "Hannah" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TourId",
                table: "Orders",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
