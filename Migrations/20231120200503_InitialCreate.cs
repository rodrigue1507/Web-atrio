using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_atrio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emploies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomEntreprise = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PosteOcupe = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateDebut = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emploies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateNaissance = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploiPersonne",
                columns: table => new
                {
                    EmploiesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonnesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploiPersonne", x => new { x.EmploiesId, x.PersonnesId });
                    table.ForeignKey(
                        name: "FK_EmploiPersonne_Emploies_EmploiesId",
                        column: x => x.EmploiesId,
                        principalTable: "Emploies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploiPersonne_Personnes_PersonnesId",
                        column: x => x.PersonnesId,
                        principalTable: "Personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploiPersonne_PersonnesId",
                table: "EmploiPersonne",
                column: "PersonnesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploiPersonne");

            migrationBuilder.DropTable(
                name: "Emploies");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
