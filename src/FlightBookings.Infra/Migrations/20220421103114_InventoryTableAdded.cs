using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookings.Infra.Data.Migrations
{
    public partial class InventoryTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AirlineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToPlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDays = table.Column<short>(type: "smallint", nullable: false),
                    InstrumentUsed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    NonBusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    TicketPrice = table.Column<int>(type: "int", nullable: false),
                    NumberOfRows = table.Column<int>(type: "int", nullable: false),
                    Meals = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Airports_FromPlaceId",
                        column: x => x.FromPlaceId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Airports_ToPlaceId",
                        column: x => x.ToPlaceId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmationCode", "Email", "PasswordHash", "Phone", "Role", "Salt", "Status", "Username" },
                values: new object[] { new Guid("1b61edcd-aac5-4aeb-896a-6b197afe90d3"), null, "admin@yopmail.com", "$2a$11$x/VPHQFtPOID3//S/XkhMO9SWopKS6VYzdL0NkrnYmvu8SfzVGu9K", "7889379123", (byte)1, "$2a$11$x/VPHQFtPOID3//S/XkhMO", (byte)0, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_AirlineId",
                table: "Inventories",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_FromPlaceId",
                table: "Inventories",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ToPlaceId",
                table: "Inventories",
                column: "ToPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b61edcd-aac5-4aeb-896a-6b197afe90d3"));
        }
    }
}
