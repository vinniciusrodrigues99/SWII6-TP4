﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vrumvrum.Context;

#nullable disable

namespace vrumvrum.Migrations
{
    [DbContext(typeof(VrumDbContext))]
    [Migration("20240321235032_relacionamento de campeonato para corrida e equipes")]
    partial class relacionamentodecampeonatoparacorridaeequipes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("vrumvrum.Models.Campeonato", b =>
                {
                    b.Property<int>("id_campeonato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_campeonato"), 1L, 1);

                    b.Property<int>("ano")
                        .HasColumnType("int");

                    b.Property<string>("categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_campeonato");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("vrumvrum.Models.Corrida", b =>
                {
                    b.Property<int>("id_corrida")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_corrida"), 1L, 1);

                    b.Property<int>("CampeonatoId")
                        .HasColumnType("int");

                    b.Property<string>("nome_corrida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("tamanho_circuito")
                        .HasColumnType("float");

                    b.Property<int>("voltas")
                        .HasColumnType("int");

                    b.HasKey("id_corrida");

                    b.HasIndex("CampeonatoId");

                    b.ToTable("Corridas");
                });

            modelBuilder.Entity("vrumvrum.Models.Equipe", b =>
                {
                    b.Property<int>("id_equipe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_equipe"), 1L, 1);

                    b.Property<int?>("CampeonatoId")
                        .HasColumnType("int");

                    b.Property<string>("nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_equipe");

                    b.HasIndex("CampeonatoId");

                    b.ToTable("Equipes");
                });

            modelBuilder.Entity("vrumvrum.Models.Piloto", b =>
                {
                    b.Property<int>("id_piloto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_piloto"), 1L, 1);

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<string>("nacionalidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_piloto");

                    b.HasIndex("EquipeId");

                    b.ToTable("Pilotos");
                });

            modelBuilder.Entity("vrumvrum.Models.Corrida", b =>
                {
                    b.HasOne("vrumvrum.Models.Campeonato", "Campeonato")
                        .WithMany("Corridas")
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campeonato");
                });

            modelBuilder.Entity("vrumvrum.Models.Equipe", b =>
                {
                    b.HasOne("vrumvrum.Models.Campeonato", "Campeonato")
                        .WithMany("Equipes")
                        .HasForeignKey("CampeonatoId");

                    b.Navigation("Campeonato");
                });

            modelBuilder.Entity("vrumvrum.Models.Piloto", b =>
                {
                    b.HasOne("vrumvrum.Models.Equipe", "Equipe")
                        .WithMany("Pilotos")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("vrumvrum.Models.Campeonato", b =>
                {
                    b.Navigation("Corridas");

                    b.Navigation("Equipes");
                });

            modelBuilder.Entity("vrumvrum.Models.Equipe", b =>
                {
                    b.Navigation("Pilotos");
                });
#pragma warning restore 612, 618
        }
    }
}
