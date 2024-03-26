﻿// <auto-generated />
using System;
using API_Museu_da_computacao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Museu_da_computacao.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240315194438_StringDeslike")]
    partial class StringDeslike
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API_Museu_da_computacao.Models.AvaliacaoDeslike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int?>("AvaliacaoDeslike")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("IdUser");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoDeslike");

                    b.ToTable("AvaliacaoDeslike");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.AvaliacaoLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int?>("AvaliacaoLike")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("IdUser");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoLike");

                    b.ToTable("AvaliacaoLike");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.ItemAcervo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("DescricaoItem")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DescricaoItem");

                    b.Property<string>("Imagem1Item")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Imagem1Item");

                    b.Property<string>("NomeItem")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("NomeItem");

                    b.Property<int?>("NotaItemDesLike")
                        .HasColumnType("int")
                        .HasColumnName("NotaItemDesLike");

                    b.Property<int?>("NotaItemLike")
                        .HasColumnType("int")
                        .HasColumnName("NotaItemLike");

                    b.HasKey("Id");

                    b.ToTable("ItensAcervo");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.Noticias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("DescricaoNoticia")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("DescricaoNoticia");

                    b.Property<string>("Imagem1Item")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ImagemNoticia");

                    b.Property<string>("TituloNoticia")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("TituloNoticia");

                    b.HasKey("Id");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdUser");

                    b.Property<string>("UsuarioGoogleID")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("UsuarioGoogleID");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.AvaliacaoDeslike", b =>
                {
                    b.HasOne("API_Museu_da_computacao.Models.ItemAcervo", null)
                        .WithMany("Deslike")
                        .HasForeignKey("AvaliacaoDeslike");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.AvaliacaoLike", b =>
                {
                    b.HasOne("API_Museu_da_computacao.Models.ItemAcervo", null)
                        .WithMany("like")
                        .HasForeignKey("AvaliacaoLike");
                });

            modelBuilder.Entity("API_Museu_da_computacao.Models.ItemAcervo", b =>
                {
                    b.Navigation("Deslike");

                    b.Navigation("like");
                });
#pragma warning restore 612, 618
        }
    }
}
