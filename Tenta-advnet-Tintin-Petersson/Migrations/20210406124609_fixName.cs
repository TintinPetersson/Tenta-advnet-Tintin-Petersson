using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class fixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_Cage_BuddiesId",
                table: "Hamsters");

            migrationBuilder.RenameColumn(
                name: "Cage_BuddiesId",
                table: "Hamsters",
                newName: "CageId");

            migrationBuilder.RenameIndex(
                name: "IX_Hamsters_Cage_BuddiesId",
                table: "Hamsters",
                newName: "IX_Hamsters_CageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_CageId",
                table: "Hamsters",
                column: "CageId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_CageId",
                table: "Hamsters");

            migrationBuilder.RenameColumn(
                name: "CageId",
                table: "Hamsters",
                newName: "Cage_BuddiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Hamsters_CageId",
                table: "Hamsters",
                newName: "IX_Hamsters_Cage_BuddiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_Cage_BuddiesId",
                table: "Hamsters",
                column: "Cage_BuddiesId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
