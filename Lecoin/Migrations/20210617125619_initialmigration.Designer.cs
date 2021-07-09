﻿// <auto-generated />
using System;
using Lecoin.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lecoin.Migrations
{
    [DbContext(typeof(LecoinContext))]
    [Migration("20210617125619_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lecoin.Models.Articles", b =>
                {
                    b.Property<int>("IdArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomVendeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prix")
                        .HasColumnType("int");

                    b.Property<int>("QuantitéDispo")
                        .HasColumnType("int");

                    b.HasKey("IdArticle");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Lecoin.Models.Categories", b =>
                {
                    b.Property<int>("IdCategories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NOmCategorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nbres")
                        .HasColumnType("int");

                    b.HasKey("IdCategories");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Lecoin.Models.Clients", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email_client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NOmComplet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom_client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom_client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel_client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Lecoin.Models.Commande", b =>
                {
                    b.Property<int>("IdCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPanier")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelivred")
                        .HasColumnType("bit");

                    b.Property<string>("Lieu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Livraison")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomVendeur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomclient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCommande")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCommande");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("Lecoin.Models.Information", b =>
                {
                    b.Property<int>("IdInfo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInfo");

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("Lecoin.Models.Negociation", b =>
                {
                    b.Property<int>("IdNegociation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<bool>("Issuccess")
                        .HasColumnType("bit");

                    b.Property<string>("NomArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomVendeur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrixNormal")
                        .HasColumnType("int");

                    b.Property<int>("PrixPropose")
                        .HasColumnType("int");

                    b.Property<int>("Quantité")
                        .HasColumnType("int");

                    b.HasKey("IdNegociation");

                    b.ToTable("Negociations");
                });

            modelBuilder.Entity("Lecoin.Models.Panier", b =>
                {
                    b.Property<int>("IdPanier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<bool>("IsActif")
                        .HasColumnType("bit");

                    b.Property<string>("NomArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomVendeur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoArticle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantité")
                        .HasColumnType("int");

                    b.Property<int>("SommeTotale")
                        .HasColumnType("int");

                    b.HasKey("IdPanier");

                    b.ToTable("Paniers");
                });
#pragma warning restore 612, 618
        }
    }
}
