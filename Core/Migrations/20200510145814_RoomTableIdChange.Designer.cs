﻿// <auto-generated />
using System;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Migrations
{
    [DbContext(typeof(ReservationContext))]
    [Migration("20200510145814_RoomTableIdChange")]
    partial class RoomTableIdChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Attribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AirCon")
                        .HasColumnType("bit");

                    b.Property<bool>("Computers")
                        .HasColumnType("bit");

                    b.Property<bool>("Jacks")
                        .HasColumnType("bit");

                    b.Property<bool>("Presenter")
                        .HasColumnType("bit");

                    b.HasKey("AttributeId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Core.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReservationId");

                    b.HasIndex("RoomId");

                    b.HasIndex("Username");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Core.Right", b =>
                {
                    b.Property<string>("RightsName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RightsName");

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("Core.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttributeId")
                        .HasColumnType("int");

                    b.Property<string>("Building")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNr")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.HasIndex("AttributeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Core.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RightsName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Username");

                    b.HasIndex("RightsName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Reservation", b =>
                {
                    b.HasOne("Core.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.HasOne("Core.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("Core.Room", b =>
                {
                    b.HasOne("Core.Attribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");
                });

            modelBuilder.Entity("Core.User", b =>
                {
                    b.HasOne("Core.Right", "Rights")
                        .WithMany("UserHasRight")
                        .HasForeignKey("RightsName");
                });
#pragma warning restore 612, 618
        }
    }
}
