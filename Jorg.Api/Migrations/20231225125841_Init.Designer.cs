﻿// <auto-generated />
using Jorg.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jorg.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231225125841_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jorg.Api.Models.CountryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alpha")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int>("Continent")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alpha = "BIH",
                            Continent = 3,
                            Country = "Bosna i Hercegovina"
                        },
                        new
                        {
                            Id = 2,
                            Alpha = "MNE",
                            Continent = 3,
                            Country = "Crna Gora"
                        },
                        new
                        {
                            Id = 3,
                            Alpha = "HRV",
                            Continent = 3,
                            Country = "Hrvatska"
                        },
                        new
                        {
                            Id = 4,
                            Alpha = "MKD",
                            Continent = 3,
                            Country = "Republika Makedonija"
                        },
                        new
                        {
                            Id = 5,
                            Alpha = "SVN",
                            Continent = 3,
                            Country = "Slovenija"
                        },
                        new
                        {
                            Id = 6,
                            Alpha = "SRB",
                            Continent = 3,
                            Country = "Srbija"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
