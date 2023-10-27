using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMonitoring.Migrations
{
    public partial class _202310043 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Harvests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Harvests_RoomId",
                table: "Harvests",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Harvests_Rooms_RoomId",
                table: "Harvests",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Harvests_Rooms_RoomId",
                table: "Harvests");

            migrationBuilder.DropIndex(
                name: "IX_Harvests_RoomId",
                table: "Harvests");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Harvests");
        }
    }
}
