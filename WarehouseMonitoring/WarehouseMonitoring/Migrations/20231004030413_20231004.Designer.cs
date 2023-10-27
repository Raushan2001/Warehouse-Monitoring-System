﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseMonitoring.Context;

#nullable disable

namespace WarehouseMonitoring.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231004030413_20231004")]
    partial class _20231004
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WarehouseMonitoring.Models.CroupType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("FreezingPoint")
                        .HasColumnType("float");

                    b.Property<int>("MaxStorageLife")
                        .HasColumnType("int");

                    b.Property<int>("MinStorageLife")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CroupTypes", (string)null);
                });

            modelBuilder.Entity("WarehouseMonitoring.Models.Harvest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CroupTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfStorage")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxHumidity")
                        .HasColumnType("int");

                    b.Property<double>("MaxTemperature")
                        .HasColumnType("float");

                    b.Property<int>("MinHumidity")
                        .HasColumnType("int");

                    b.Property<double>("MinTemperature")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CroupTypeId");

                    b.ToTable("Harvests", (string)null);
                });

            modelBuilder.Entity("WarehouseMonitoring.Models.Harvest", b =>
                {
                    b.HasOne("WarehouseMonitoring.Models.CroupType", "CroupType")
                        .WithMany()
                        .HasForeignKey("CroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CroupType");
                });
#pragma warning restore 612, 618
        }
    }
}
