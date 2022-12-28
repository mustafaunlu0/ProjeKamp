﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjeKamp.Context;

#nullable disable

namespace ProjeKamp.Migrations
{
    [DbContext(typeof(CampDataContext))]
    partial class CampDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

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

                    b.Property<string>("PostCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostCounty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostHour")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostMap")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostUri")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProjeKamp.Models.PostDetail", b =>
                {
                    b.Property<int>("detailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("detailId"));

                    b.Property<int>("ParticipantId")
                        .HasColumnType("integer");

                    b.Property<int>("postId")
                        .HasColumnType("integer");

                    b.HasKey("detailId");

                    b.ToTable("PostDetail");
                });

            modelBuilder.Entity("ProjeKamp.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleDetail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ProjeKamp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("UserId"));

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

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
#pragma warning restore 612, 618
        }
    }
}
