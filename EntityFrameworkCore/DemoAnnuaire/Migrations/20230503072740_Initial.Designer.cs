﻿// <auto-generated />
using DemoAnnuaire.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoAnnuaire.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230503072740_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoAnnuaire.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CodePostal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commune")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplementAdresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntituleVoie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroVoie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });
#pragma warning restore 612, 618
        }
    }
}
