using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class fixed_activity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logg_Activities_Hamsters_HamsterId",
                table: "Logg_Activities");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "Logg_Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Logg_Activities_Hamsters_HamsterId",
                table: "Logg_Activities",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logg_Activities_Hamsters_HamsterId",
                table: "Logg_Activities");

            migrationBuilder.AlterColumn<int>(
                name: "HamsterId",
                table: "Logg_Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Logg_Activities_Hamsters_HamsterId",
                table: "Logg_Activities",
                column: "HamsterId",
                principalTable: "Hamsters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
