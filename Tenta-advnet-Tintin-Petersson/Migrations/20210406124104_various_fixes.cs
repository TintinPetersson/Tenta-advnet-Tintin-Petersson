using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenta_advnet_Tintin_Petersson.Migrations
{
    public partial class various_fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_Buddies_Cage_BuddiesId",
                table: "Hamsters");

            migrationBuilder.DropTable(
                name: "Cage_Buddies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cages",
                table: "Cages");

            migrationBuilder.RenameTable(
                name: "Cages",
                newName: "Cage");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Cage",
                newName: "MaxCapacity");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Cage",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cage",
                table: "Cage",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cage",
                columns: new[] { "Id", "Gender", "MaxCapacity" },
                values: new object[,]
                {
                    { 1, null, 3 },
                    { 2, null, 3 },
                    { 3, null, 3 },
                    { 4, null, 3 },
                    { 5, null, 3 },
                    { 6, null, 3 },
                    { 7, null, 3 },
                    { 8, null, 3 },
                    { 9, null, 3 },
                    { 10, null, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_Cage_BuddiesId",
                table: "Hamsters",
                column: "Cage_BuddiesId",
                principalTable: "Cage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hamsters_Cage_Cage_BuddiesId",
                table: "Hamsters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cage",
                table: "Cage");

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Cage");

            migrationBuilder.RenameTable(
                name: "Cage",
                newName: "Cages");

            migrationBuilder.RenameColumn(
                name: "MaxCapacity",
                table: "Cages",
                newName: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cages",
                table: "Cages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cage_Buddies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CageId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cage_Buddies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cage_Buddies_Cages_CageId",
                        column: x => x.CageId,
                        principalTable: "Cages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cage_Buddies_CageId",
                table: "Cage_Buddies",
                column: "CageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hamsters_Cage_Buddies_Cage_BuddiesId",
                table: "Hamsters",
                column: "Cage_BuddiesId",
                principalTable: "Cage_Buddies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
