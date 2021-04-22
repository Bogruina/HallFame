﻿// <auto-generated />
using System;
using HallOfFame.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AppContext = HallOfFame.Models.AppContext;


namespace HallFame.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210422054334_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HallOfFame.Models.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DisplayName = "Alex",
                            Name = "Alexey"
                        },
                        new
                        {
                            Id = 2L,
                            DisplayName = "Lera",
                            Name = "Valeria"
                        },
                        new
                        {
                            Id = 3L,
                            DisplayName = "Olya",
                            Name = "Olga"
                        });
                });

            modelBuilder.Entity("HallOfFame.Models.Skill", b =>
                {
                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Level")
                        .HasColumnType("tinyint");

                    b.HasKey("PersonId", "Name");

                    b.ToTable("Skills");

                    b.HasData(
                        new
                        {
                            PersonId = 2L,
                            Name = "WPF",
                            Level = (byte)2
                        },
                        new
                        {
                            PersonId = 3L,
                            Name = "C#",
                            Level = (byte)5
                        },
                        new
                        {
                            PersonId = 4L,
                            Name = "Data Science",
                            Level = (byte)10
                        },
                        new
                        {
                            PersonId = 5L,
                            Name = "SQL",
                            Level = (byte)11
                        });
                });

            modelBuilder.Entity("HallOfFame.Models.Skill", b =>
                {
                    b.HasOne("HallOfFame.Models.Person", null)
                        .WithMany("Skills")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HallOfFame.Models.Person", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
