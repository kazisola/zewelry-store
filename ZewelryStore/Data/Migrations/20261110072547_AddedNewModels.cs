using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZewelryStore.Data.Migrations
{
    public partial class AddedNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quanitity",
                table: "OrderItems",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "Quanitity");
        }
    }
}