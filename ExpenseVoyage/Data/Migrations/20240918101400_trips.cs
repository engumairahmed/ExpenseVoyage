using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseVoyage.Data.Migrations
{
    public partial class trips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trip_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trips_UserProfiles_user_id",
                        column: x => x.user_id,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_user_id",
                table: "Trips",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "UserProfiles");
        }
    }
}
