﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPIdemo.Models;

#nullable disable

namespace WebAPIdemo.Migrations
{
    [DbContext(typeof(WebAPIdbContext))]
    [Migration("20230729101153_DBCreation")]
    partial class DBCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoApps.Models.Category", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "AZ100",
                            CategoryName = "Bread",
                            Description = "Baked goods made of flour, water and salt combined with various additives."
                        },
                        new
                        {
                            CategoryId = "AZ200",
                            CategoryName = "Alkohol free drinks",
                            Description = "A type of beverage that does not contain significant amounts of alcohol."
                        },
                        new
                        {
                            CategoryId = "AZ300",
                            CategoryName = "Instant dishes",
                            Description = "Instant product that is ready in a few minutes after pouring boiling water or other liquid.."
                        });
                });

            modelBuilder.Entity("DemoApps.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = "WZ100",
                            CategoryId = "AZ100",
                            ProductName = "Cereal Bread",
                            UnitPrice = 4m,
                            UnitsInStock = 20
                        },
                        new
                        {
                            ProductId = "WZ200",
                            CategoryId = "AZ200",
                            ProductName = "Cola",
                            UnitPrice = 8m,
                            UnitsInStock = 10
                        },
                        new
                        {
                            ProductId = "WZ300",
                            CategoryId = "AZ300",
                            ProductName = "Instant soup",
                            UnitPrice = 3m,
                            UnitsInStock = 50
                        },
                        new
                        {
                            ProductId = "WZ400",
                            CategoryId = "AZ100",
                            ProductName = "Wheat roll",
                            UnitPrice = 1m,
                            UnitsInStock = 15
                        },
                        new
                        {
                            ProductId = "WZ500",
                            CategoryId = "AZ300",
                            ProductName = "Instant puree",
                            UnitPrice = 10m,
                            UnitsInStock = 35
                        });
                });

            modelBuilder.Entity("DemoApps.Models.Product", b =>
                {
                    b.HasOne("DemoApps.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
