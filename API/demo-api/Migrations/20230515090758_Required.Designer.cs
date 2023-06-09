﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using demo_api.Data;

#nullable disable

namespace demo_api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230515090758_Required")]
    partial class Required
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("demo_api.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 29,
                            AvatarUrl = "",
                            BirthDate = new DateTime(1993, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Maxime",
                            FullName = "Maxime Maillot",
                            LastName = "Maillot",
                            Sexe = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Age = 37,
                            AvatarUrl = "",
                            BirthDate = new DateTime(1986, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Martial",
                            FullName = "Martial Maillot",
                            LastName = "Maillot",
                            Sexe = "Male"
                        },
                        new
                        {
                            Id = 3,
                            Age = 37,
                            AvatarUrl = "",
                            BirthDate = new DateTime(1989, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mathilde",
                            FullName = "Mathilde Maillot",
                            LastName = "Vermuse",
                            Sexe = "Female"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
