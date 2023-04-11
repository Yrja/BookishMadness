﻿// <auto-generated />
using System;
using BookishMadness.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookishMadness.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230411134728_Add_Book_Status")]
    partial class Add_Book_Status
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookishMadness.DAL.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagesCount")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("17f8b524-7d55-4201-9c7c-a7fad54845ec"),
                            Author = "J. R. R. Tolkien",
                            Description = "Description",
                            Name = "Lord of the ring",
                            PagesCount = 0,
                            Status = "Reading"
                        },
                        new
                        {
                            Id = new Guid("4583cf5c-402f-410a-9cdb-309d8b498774"),
                            Author = "Stephanie Garber",
                            Description = "Description",
                            Name = "Caraval",
                            PagesCount = 0,
                            Status = "Reading"
                        },
                        new
                        {
                            Id = new Guid("163c0025-33f7-46aa-8069-95b53b37df86"),
                            Author = "L. J. Shenn",
                            Description = "Description",
                            Name = "Pretty reckless",
                            PagesCount = 0,
                            Status = "WantToRead"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}