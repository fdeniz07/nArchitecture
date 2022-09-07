﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RentACar.Persistence.Contexts;

#nullable disable

namespace RentACar.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220907190124_mig_1_AddModelEntity")]
    partial class mig_1_AddModelEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RentACar.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 2,
                            Name = "VW"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Opel"
                        });
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer")
                        .HasColumnName("BrandId");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("DailyPrice");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            DailyPrice = 1500m,
                            ImageUrl = "",
                            Name = "Series 4"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            DailyPrice = 1200m,
                            ImageUrl = "",
                            Name = "Series 3"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 2,
                            DailyPrice = 1000m,
                            ImageUrl = "",
                            Name = "A180"
                        });
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Model", b =>
                {
                    b.HasOne("RentACar.Domain.Entities.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("RentACar.Domain.Entities.Brand", b =>
                {
                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
