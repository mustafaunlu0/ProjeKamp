﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjeKamp.Context;

#nullable disable

namespace ProjeKamp.Migrations
{
    [DbContext(typeof(CampDataContext))]
    [Migration("20221207095437_son")]
    partial class son
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("ProjeKamp.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdminLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ProjeKamp.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("PostId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfParticipants")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfUndecided")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.HasIndex("AdminId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProjeKamp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("UserId"));

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserLastName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjeKamp.Models.Post", b =>
                {
                    b.HasOne("ProjeKamp.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });
#pragma warning restore 612, 618
        }
    }
}
