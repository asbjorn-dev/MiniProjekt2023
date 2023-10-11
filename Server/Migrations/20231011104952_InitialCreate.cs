using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bruger",
                columns: table => new
                {
                    BrugerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brugernavn = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bruger", x => x.BrugerId);
                });

            migrationBuilder.CreateTable(
                name: "Trådes",
                columns: table => new
                {
                    TrådeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tråde_Overskrift = table.Column<string>(type: "TEXT", nullable: false),
                    Tekst = table.Column<string>(type: "TEXT", nullable: false),
                    Antal_Stemmer = table.Column<int>(type: "INTEGER", nullable: true),
                    Upvote = table.Column<int>(type: "INTEGER", nullable: true),
                    Downvote = table.Column<int>(type: "INTEGER", nullable: true),
                    BrugerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trådes", x => x.TrådeId);
                    table.ForeignKey(
                        name: "FK_Trådes_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "BrugerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kommentar",
                columns: table => new
                {
                    KommentarId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tekst = table.Column<string>(type: "TEXT", nullable: false),
                    Dato = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Upvote = table.Column<int>(type: "INTEGER", nullable: true),
                    Downvote = table.Column<int>(type: "INTEGER", nullable: true),
                    BrugerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrådeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kommentar", x => x.KommentarId);
                    table.ForeignKey(
                        name: "FK_Kommentar_Bruger_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Bruger",
                        principalColumn: "BrugerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kommentar_Trådes_TrådeId",
                        column: x => x.TrådeId,
                        principalTable: "Trådes",
                        principalColumn: "TrådeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_BrugerId",
                table: "Kommentar",
                column: "BrugerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kommentar_TrådeId",
                table: "Kommentar",
                column: "TrådeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trådes_BrugerId",
                table: "Trådes",
                column: "BrugerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kommentar");

            migrationBuilder.DropTable(
                name: "Trådes");

            migrationBuilder.DropTable(
                name: "Bruger");
        }
    }
}
