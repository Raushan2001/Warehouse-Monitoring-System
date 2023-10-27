using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarehouseMonitoring.Migrations
{
    public partial class _202310044 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "RoomDetails",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "RoomDetails");
        }
    }
}
