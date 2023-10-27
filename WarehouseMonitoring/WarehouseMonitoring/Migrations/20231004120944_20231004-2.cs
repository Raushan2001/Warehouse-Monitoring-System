using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMonitoring.Migrations
{
    public partial class _202310042 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxHumidity",
                table: "Harvests");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Harvests");

            migrationBuilder.DropColumn(
                name: "MinHumidity",
                table: "Harvests");

            migrationBuilder.RenameColumn(
                name: "MinTemperature",
                table: "Harvests",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "MaxHumidity",
                table: "CroupTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "CroupTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MinHumidity",
                table: "CroupTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MinTemperature",
                table: "CroupTypes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Tempreature = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomDetails_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomDetails_RoomId",
                table: "RoomDetails",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomDetails");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropColumn(
                name: "MaxHumidity",
                table: "CroupTypes");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "CroupTypes");

            migrationBuilder.DropColumn(
                name: "MinHumidity",
                table: "CroupTypes");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "CroupTypes");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Harvests",
                newName: "MinTemperature");

            migrationBuilder.AddColumn<int>(
                name: "MaxHumidity",
                table: "Harvests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "Harvests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MinHumidity",
                table: "Harvests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
