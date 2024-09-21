using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseVoyage.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Expenses",
                newName: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_category_id",
                table: "Expenses",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_categories_category_id",
                table: "Expenses",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_categories_category_id",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_category_id",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Expenses",
                newName: "Category");
        }
    }
}
