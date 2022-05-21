﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ArteNaPraia.Migrations
{
    [DbContext(typeof(ArteNaPraiaContext))]
    [Migration("20220510225227_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ArteNaPraia.Models.Arte", b =>
                {
                    b.Property<int>("IdArte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("IdArtista")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.HasKey("IdArte");

                    b.HasIndex("IdArtista");

                    b.ToTable("Arte");
                });

            modelBuilder.Entity("ArteNaPraia.Models.Artista", b =>
                {
                    b.Property<int>("IdArtista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ChavePix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("IdArtista");

                    b.ToTable("Artista");
                });

            modelBuilder.Entity("ArteNaPraia.Models.Arte", b =>
                {
                    b.HasOne("ArteNaPraia.Models.Artista", "Artista")
                        .WithMany("Artes")
                        .HasForeignKey("IdArtista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
