﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeaceHotelAPI.Data;

namespace PeaceHotelAPI.Migrations
{
    [DbContext(typeof(PeaceHotelAPIDbContext))]
    [Migration("20210305171018_AmendedRoomEntity2")]
    partial class AmendedRoomEntity2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeaceHotelAPI.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("PeaceHotelAPI.Entities.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCheckedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateCheckedOut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.Property<int?>("RoomNo1")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("RoomNo1");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PeaceHotelAPI.Entities.Room", b =>
                {
                    b.Property<int>("RoomNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("RoomCost")
                        .HasColumnType("float");

                    b.Property<int>("RoomFree")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomOccupant")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomNo");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PeaceHotelAPI.Entities.Client", b =>
                {
                    b.HasOne("PeaceHotelAPI.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomNo1");

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
