using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOneShots.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(type: "TEXT", nullable: false),
                    PolePosition = table.Column<string>(type: "TEXT", nullable: false),
                    RandomGuess = table.Column<string>(type: "TEXT", nullable: true),
                    LastChange = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Driver = table.Column<string>(type: "TEXT", nullable: false),
                    ShotsId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_Shots_ShotsId",
                        column: x => x.ShotsId,
                        principalTable: "Shots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_ShotsId",
                table: "Result",
                column: "ShotsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Shots");
        }
    }
}
