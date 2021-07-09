using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lecoin.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    IdArticle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomArticle = table.Column<string>(nullable: false),
                    Prix = table.Column<int>(nullable: false),
                    Categorie = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    NomVendeur = table.Column<string>(nullable: false),
                    PhotoArticle = table.Column<string>(nullable: false),
                    QuantitéDispo = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.IdArticle);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategories = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOmCategorie = table.Column<string>(nullable: true),
                    Nbres = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategories);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_client = table.Column<string>(nullable: false),
                    Prenom_client = table.Column<string>(nullable: false),
                    Tel_client = table.Column<string>(nullable: false),
                    Email_client = table.Column<string>(nullable: false),
                    MotDePasse = table.Column<string>(nullable: false),
                    NOmComplet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    IdCommande = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPanier = table.Column<int>(nullable: false),
                    Nomclient = table.Column<string>(nullable: true),
                    NumeroCommande = table.Column<string>(nullable: true),
                    NomVendeur = table.Column<string>(nullable: true),
                    Lieu = table.Column<string>(nullable: true),
                    Livraison = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    IsDelivred = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.IdCommande);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    IdInfo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Titre = table.Column<string>(nullable: false),
                    Contact = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.IdInfo);
                });

            migrationBuilder.CreateTable(
                name: "Negociations",
                columns: table => new
                {
                    IdNegociation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArticle = table.Column<int>(nullable: false),
                    NomClient = table.Column<string>(nullable: true),
                    NomArticle = table.Column<string>(nullable: true),
                    NomVendeur = table.Column<string>(nullable: true),
                    Quantité = table.Column<int>(nullable: false),
                    PrixPropose = table.Column<int>(nullable: false),
                    PrixNormal = table.Column<int>(nullable: false),
                    Issuccess = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negociations", x => x.IdNegociation);
                });

            migrationBuilder.CreateTable(
                name: "Paniers",
                columns: table => new
                {
                    IdPanier = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClient = table.Column<string>(nullable: true),
                    IdArticle = table.Column<int>(nullable: false),
                    NomArticle = table.Column<string>(nullable: true),
                    Categorie = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NomVendeur = table.Column<string>(nullable: true),
                    PhotoArticle = table.Column<string>(nullable: true),
                    SommeTotale = table.Column<int>(nullable: false),
                    Quantité = table.Column<int>(nullable: false),
                    IsActif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paniers", x => x.IdPanier);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "Negociations");

            migrationBuilder.DropTable(
                name: "Paniers");
        }
    }
}
