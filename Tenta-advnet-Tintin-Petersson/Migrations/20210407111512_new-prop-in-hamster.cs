using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class newpropinhamster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseAreaId",
                table: "Hamsters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OldCageId",
                table: "Hamsters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hamsters_ExerciseAreaId",
                table: "Hamsters",
                column: "ExerciseAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_ExerciseAreas_ExerciseAreaId",
                table: "Hamsters",
                column: "ExerciseAreaId",
                principalTable: "ExerciseAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_ExerciseAreas_ExerciseAreaId",
                table: "Hamsters");

            migrationBuilder.DropIndex(
                name: "IX_Hamsters_ExerciseAreaId",
                table: "Hamsters");

            migrationBuilder.DropColumn(
                name: "ExerciseAreaId",
                table: "Hamsters");

            migrationBuilder.DropColumn(
                name: "OldCageId",
                table: "Hamsters");
        }
    }
}
