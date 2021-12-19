using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddedItemTypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "FoodItems");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_TypeId",
                table: "FoodItems",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodItems_ItemTypes_TypeId",
                table: "FoodItems",
                column: "TypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodItems_ItemTypes_TypeId",
                table: "FoodItems");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodItems_TypeId",
                table: "FoodItems");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "FoodItems");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FoodItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
