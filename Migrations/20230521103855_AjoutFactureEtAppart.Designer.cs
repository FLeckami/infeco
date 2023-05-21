﻿// <auto-generated />
using System;
using Infeco.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace infeco.Migrations
{
    [DbContext(typeof(InfecoContext))]
    [Migration("20230521103855_AjoutFactureEtAppart")]
    partial class AjoutFactureEtAppart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infeco.Models.Appartement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Appartement");
                });

            modelBuilder.Entity("Infeco.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<string>("NumeroTel")
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .HasColumnType("text");

                    b.Property<float>("Solde")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Infeco.Models.Facture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DatePaiement")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdClient")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Facture");
                });

            modelBuilder.Entity("Infeco.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int?>("IdAppartement")
                        .HasColumnType("integer");

                    b.Property<int?>("IdClient")
                        .HasColumnType("integer");

                    b.Property<float>("MontantDepotGarantie")
                        .HasColumnType("real");

                    b.Property<float>("MontantLoyer")
                        .HasColumnType("real");

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Infeco.Models.Facture", b =>
                {
                    b.HasOne("Infeco.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Infeco.Models.Location", b =>
                {
                    b.HasOne("Infeco.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
