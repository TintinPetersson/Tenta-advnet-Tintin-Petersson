using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Logg_Activities_Logg_ActivitiesId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_Logg_ActivitiesId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "Logg_ActivitiesId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Logg_Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 11,
                column: "Gender",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logg_Activities_ActivityId",
                table: "Logg_Activities",
                column: "ActivityId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Logg_Activities_Activities_ActivityId",
                table: "Logg_Activities",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Activities_ActivityId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Logg_Activities_Activities_ActivityId",
                table: "Logg_Activities");

            migrationBuilder.DropIndex(
                name: "IX_Logg_Activities_ActivityId",
                table: "Logg_Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ActivityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Logg_Activities");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "Logg_ActivitiesId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Hamsters",
                keyColumn: "Id",
                keyValue: 11,
                column: "Gender",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_Logg_ActivitiesId",
                table: "Activities",
                column: "Logg_ActivitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Logg_Activities_Logg_ActivitiesId",
                table: "Activities",
                column: "Logg_ActivitiesId",
                principalTable: "Logg_Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
