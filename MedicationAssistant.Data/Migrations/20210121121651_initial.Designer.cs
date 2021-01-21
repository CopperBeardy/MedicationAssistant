﻿// <auto-generated />
using System;
using MedicationAssistant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicationAssistant.Data.Migrations
{
    [DbContext(typeof(MedicationAssistantDBContext))]
    [Migration("20210121121651_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MedicationAssistant.Shared.Models.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Dosage")
                        .HasColumnType("int");

                    b.Property<int>("DosageUnit")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("UseDirections")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CollectedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.PrescriptionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<double>("FrequencyUnit")
                        .HasColumnType("float");

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int?>("PrescriptionId")
                        .HasColumnType("int");

                    b.Property<int?>("PrescriptionItemAlertId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PrescriptionId");

                    b.HasIndex("PrescriptionItemAlertId");

                    b.ToTable("PrescriptionItems");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.PrescriptionItemAlert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("StartFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PrescriptionAlerts");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.Prescription", b =>
                {
                    b.HasOne("MedicationAssistant.Shared.Models.User", "User")
                        .WithMany("Prescriptions")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.PrescriptionItem", b =>
                {
                    b.HasOne("MedicationAssistant.Shared.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicationAssistant.Shared.Models.Prescription", null)
                        .WithMany("PrescriptionItems")
                        .HasForeignKey("PrescriptionId");

                    b.HasOne("MedicationAssistant.Shared.Models.PrescriptionItemAlert", null)
                        .WithMany("PrescriptionItems")
                        .HasForeignKey("PrescriptionItemAlertId");

                    b.Navigation("Medicine");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.PrescriptionItemAlert", b =>
                {
                    b.HasOne("MedicationAssistant.Shared.Models.User", "User")
                        .WithMany("Alerts")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionItems");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.PrescriptionItemAlert", b =>
                {
                    b.Navigation("PrescriptionItems");
                });

            modelBuilder.Entity("MedicationAssistant.Shared.Models.User", b =>
                {
                    b.Navigation("Alerts");

                    b.Navigation("Prescriptions");
                });
#pragma warning restore 612, 618
        }
    }
}