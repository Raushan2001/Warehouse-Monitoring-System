using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMonitoring.Migrations
{
    public partial class _20231004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Harvests",
                newName: "MinHumidity");

            migrationBuilder.RenameColumn(
                name: "Tempreature",
                table: "Harvests",
                newName: "MaxHumidity");

            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "Harvests",
                newName: "CroupTypeId");

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "Harvests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinTemperature",
                table: "Harvests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CroupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinStorageLife = table.Column<int>(type: "int", nullable: false),
                    MaxStorageLife = table.Column<int>(type: "int", nullable: false),
                    FreezingPoint = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CroupTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_CroupTypeId",
                table: "Harvests",
                column: "CroupTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harvests_CroupTypes_CroupTypeId",
                table: "Harvests",
                column: "CroupTypeId",
                principalTable: "CroupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harvests_CroupTypes_CroupTypeId",
                table: "Harvests");

            migrationBuilder.DropTable(
                name: "CroupTypes");

            migrationBuilder.DropIndex(
                name: "IX_Harvests_CroupTypeId",
                table: "Harvests");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Harvests");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Harvests");

            migrationBuilder.RenameColumn(
                name: "MinHumidity",
                table: "Harvests",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "MaxHumidity",
                table: "Harvests",
                newName: "Tempreature");

            migrationBuilder.RenameColumn(
                name: "CroupTypeId",
                table: "Harvests",
                newName: "Humidity");
        }
    }
}
