﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NLayer.Core.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 2, 23, 20, 12, 8, 807, DateTimeKind.Local).AddTicks(9499),
                            Name = "Sarı Kalem",
                            Price = 10m,
                            Stock = 5
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 2, 23, 20, 12, 8, 807, DateTimeKind.Local).AddTicks(9523),
                            Name = "Yeşil Kalem",
                            Price = 15m,
                            Stock = 15
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedAt = new DateTime(2023, 2, 23, 20, 12, 8, 807, DateTimeKind.Local).AddTicks(9527),
                            Name = "Kırmızı Kalem",
                            Price = 5m,
                            Stock = 3
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2023, 2, 23, 20, 12, 8, 807, DateTimeKind.Local).AddTicks(9530),
                            Name = "Kırmızı Defter",
                            Price = 8m,
                            Stock = 13
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedAt = new DateTime(2023, 2, 23, 20, 12, 8, 807, DateTimeKind.Local).AddTicks(9533),
                            Name = "Mavi Defter",
                            Price = 2m,
                            Stock = 100
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("product_features", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Kırmızı",
                            Height = 40,
                            ProductId = 3,
                            Width = 2
                        },
                        new
                        {
                            Id = 2,
                            Color = "Yeşil",
                            Height = 30,
                            ProductId = 2,
                            Width = 5
                        },
                        new
                        {
                            Id = 3,
                            Color = "Sarı",
                            Height = 20,
                            ProductId = 1,
                            Width = 1
                        },
                        new
                        {
                            Id = 4,
                            Color = "Kırmızı",
                            Height = 30,
                            ProductId = 4,
                            Width = 73
                        },
                        new
                        {
                            Id = 5,
                            Color = "Mavi",
                            Height = 50,
                            ProductId = 5,
                            Width = 55
                        });
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.HasOne("NLayer.Core.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayer.Core.Entity.ProductFeature", b =>
                {
                    b.HasOne("NLayer.Core.Entity.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NLayer.Core.Entity.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayer.Core.Entity.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });
#pragma warning restore 612, 618
        }
    }
}
