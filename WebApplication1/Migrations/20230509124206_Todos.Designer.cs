﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230509124206_Todos")]
    partial class Todos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bobo@ganjamail.com",
                            FirstName = "Bob",
                            LastName = "Marley",
                            Phone = "0607080910"
                        },
                        new
                        {
                            Id = 2,
                            Email = "elvis@rock.com",
                            FirstName = "Elvis",
                            LastName = "Presley",
                            Phone = "0607080911"
                        },
                        new
                        {
                            Id = 3,
                            Email = "mj@popking.com",
                            FirstName = "Michael",
                            LastName = "Jackson",
                            Phone = "0607080912"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Tu peux le faire",
                            Status = false,
                            Title = "Faire"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Faut y arriver",
                            Status = false,
                            Title = "Finir"
                        },
                        new
                        {
                            Id = 3,
                            Description = "L'alcool est la seule solution",
                            Status = true,
                            Title = "Déprimer"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
