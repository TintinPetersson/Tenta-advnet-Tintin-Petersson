using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class fixlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_Hamsters_HamsterId",
                table: "ActivityLogs");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "ActivityLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Hamsters_HamsterId",
                table: "ActivityLogs",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_Hamsters_HamsterId",
                table: "ActivityLogs");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "ActivityLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Hamsters_HamsterId",
                table: "ActivityLogs",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
