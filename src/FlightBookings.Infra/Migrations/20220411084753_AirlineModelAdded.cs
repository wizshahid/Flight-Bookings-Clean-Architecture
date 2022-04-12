using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookings.Infra.Data.Migrations;

public partial class AirlineModelAdded : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Airlines",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                Status = table.Column<byte>(type: "tinyint", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Airlines", x => x.Id);
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Airlines");
    }
}
