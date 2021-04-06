using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class fixActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_ActivityId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Activities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ActivityId",
                table: "Activities",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Activities_ActivityId",
                table: "Activities",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
