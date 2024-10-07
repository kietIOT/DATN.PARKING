﻿// <auto-generated />
using System;
using DATN.PARKING.DLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DATN.PARKING.DLL.Migrations
{
    [DbContext(typeof(ParkingContext))]
    partial class ParkingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.CardAssignment", b =>
                {
                    b.Property<int?>("CardAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CardAssignmentId"));

                    b.Property<int?>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CardValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CardAssignmentId");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CardAssignments");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.CardType", b =>
                {
                    b.Property<int?>("CardTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CardTypeId"));

                    b.Property<string>("CardTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardTypeId");

                    b.ToTable("CardTypes");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Customer", b =>
                {
                    b.Property<int?>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CustomerId"));

                    b.Property<string>("CCCD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FingerprintData")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RFID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.ParkingSession", b =>
                {
                    b.Property<int?>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SessionId"));

                    b.Property<DateTime?>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("ParkingSlotId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("SessionId");

                    b.HasIndex("ParkingSlotId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ParkingSessions");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.ParkingSlot", b =>
                {
                    b.Property<int?>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SlotId"));

                    b.Property<bool?>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<string>("SlotNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SlotId");

                    b.ToTable("ParkingSlots");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Payment", b =>
                {
                    b.Property<int?>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PaymentId"));

                    b.Property<decimal?>("PaymentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("SessionId")
                        .IsUnique()
                        .HasFilter("[SessionId] IS NOT NULL");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Vehicle", b =>
                {
                    b.Property<int?>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("VehicleId"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.CardAssignment", b =>
                {
                    b.HasOne("DATN.PARKING.DLL.Models.DbTable.CardType", "CardType")
                        .WithMany("CardAssignments")
                        .HasForeignKey("CardTypeId");

                    b.HasOne("DATN.PARKING.DLL.Models.DbTable.Customer", "Customer")
                        .WithMany("CardAssignments")
                        .HasForeignKey("CustomerId");

                    b.Navigation("CardType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.ParkingSession", b =>
                {
                    b.HasOne("DATN.PARKING.DLL.Models.DbTable.ParkingSlot", "ParkingSlot")
                        .WithMany("ParkingSessions")
                        .HasForeignKey("ParkingSlotId");

                    b.HasOne("DATN.PARKING.DLL.Models.DbTable.Vehicle", "Vehicle")
                        .WithMany("ParkingSessions")
                        .HasForeignKey("VehicleId");

                    b.Navigation("ParkingSlot");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Payment", b =>
                {
                    b.HasOne("DATN.PARKING.DLL.Models.DbTable.ParkingSession", "ParkingSession")
                        .WithOne("Payment")
                        .HasForeignKey("DATN.PARKING.DLL.Models.DbTable.Payment", "SessionId");

                    b.Navigation("ParkingSession");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Vehicle", b =>
                {
                    b.HasOne("DATN.PARKING.DLL.Models.DbTable.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.CardType", b =>
                {
                    b.Navigation("CardAssignments");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Customer", b =>
                {
                    b.Navigation("CardAssignments");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.ParkingSession", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.ParkingSlot", b =>
                {
                    b.Navigation("ParkingSessions");
                });

            modelBuilder.Entity("DATN.PARKING.DLL.Models.DbTable.Vehicle", b =>
                {
                    b.Navigation("ParkingSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
