using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseVoyage.Data.Migrations
{
    public partial class mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop foreign key and index related to UserId
            migrationBuilder.DropForeignKey(
                name: "FK_categories_UserProfiles_UserId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_UserId",
                table: "categories");

            // Drop the UserId column
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "categories");

            // Seed data for categories
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Travel" },
                    { 2, "Food" },
                    { 3, "Accommodation" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Re-add UserId column
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_categories_UserId",
                table: "categories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_UserProfiles_UserId",
                table: "categories",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
