using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JuleJsonApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brukere",
                columns: table => new
                {
                    BrukerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kode = table.Column<string>(nullable: true),
                    Navn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brukere", x => x.BrukerId);
                });

            migrationBuilder.CreateTable(
                name: "Drikker",
                columns: table => new
                {
                    DrikkeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abv = table.Column<double>(nullable: false),
                    Beskrivelse = table.Column<string>(nullable: true),
                    Bilde = table.Column<string>(nullable: true),
                    Bryggeri = table.Column<string>(nullable: true),
                    Land = table.Column<string>(nullable: true),
                    Navn = table.Column<string>(nullable: true),
                    Pris = table.Column<double>(nullable: false),
                    Stil = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drikker", x => x.DrikkeId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bilde = table.Column<string>(nullable: true),
                    BrukerID = table.Column<int>(nullable: false),
                    DrikkeID = table.Column<int>(nullable: false),
                    Karakter = table.Column<int>(nullable: false),
                    Nokkelord = table.Column<string>(nullable: true),
                    SmakerJul = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Brukere_BrukerID",
                        column: x => x.BrukerID,
                        principalTable: "Brukere",
                        principalColumn: "BrukerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Drikker_DrikkeID",
                        column: x => x.DrikkeID,
                        principalTable: "Drikker",
                        principalColumn: "DrikkeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BrukerID",
                table: "Ratings",
                column: "BrukerID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_DrikkeID",
                table: "Ratings",
                column: "DrikkeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Brukere");

            migrationBuilder.DropTable(
                name: "Drikker");
        }
    }
}
