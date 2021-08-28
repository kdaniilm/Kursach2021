using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class FixProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Core.Context.IApplicationContext.Products",
                table: "Core.Context.IApplicationContext.Products");

            migrationBuilder.RenameTable(
                name: "Core.Context.IApplicationContext.Products",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Core.Context.IApplicationContext.Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Core.Context.IApplicationContext.Products",
                table: "Core.Context.IApplicationContext.Products",
                column: "Id");
        }
    }
}
