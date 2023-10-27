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
    [Migration("20231017092904_20231017-1")]
    partial class _202310171
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

                    b.Property<int>("MaxHumidity")
                        .HasColumnType("int");

                    b.Property<int>("MaxStorageLife")
                        .HasColumnType("int");

                    b.Property<double>("MaxTemperature")
                        .HasColumnType("float");

                    b.Property<int>("MinHumidity")
                        .HasColumnType("int");

                    b.Property<int>("MinStorageLife")
                        .HasColumnType("int");

                    b.Property<double>("MinTemperature")
                        .HasColumnType("float");

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

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CroupTypeId");

                    b.HasIndex("RoomId");

                    b.ToTable("Harvests", (string)null);
                });

            modelBuilder.Entity("WarehouseMonitoring.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms", (string)null);
                });

            modelBuilder.Entity("WarehouseMonitoring.Models.RoomDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Humidity")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Tempreature")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomDetails", (string)null);
                });

            modelBuilder.Entity("WarehouseMonitoring.Models.Harvest", b =>
                {
                    b.HasOne("WarehouseMonitoring.Models.CroupType", "CroupType")
                        .WithMany()
                        .HasForeignKey("CroupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarehouseMonitoring.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CroupType");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("WarehouseMonitoring.Models.RoomDetail", b =>
                {
                    b.HasOne("WarehouseMonitoring.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
