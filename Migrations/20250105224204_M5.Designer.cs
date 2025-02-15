﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalonulNOST2.Data;

#nullable disable

namespace SalonulNOST2.Migrations
{
    [DbContext(typeof(SalonulNOST2Context))]
    [Migration("20250105224204_M5")]
    partial class M5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SalonulNOST2.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int?>("ServiceID")
                        .HasColumnType("int");

                    b.HasKey("AppointmentID");

                    b.HasIndex("ClientID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("AppointmentID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("ServiceID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Appointment", b =>
                {
                    b.HasOne("SalonulNOST2.Models.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientID");

                    b.HasOne("SalonulNOST2.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID");

                    b.HasOne("SalonulNOST2.Models.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceID");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Review", b =>
                {
                    b.HasOne("SalonulNOST2.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentID");

                    b.Navigation("Appointment");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Service", b =>
                {
                    b.HasOne("SalonulNOST2.Models.Employee", "Employee")
                        .WithMany("Services")
                        .HasForeignKey("EmployeeID");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Client", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Employee", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("SalonulNOST2.Models.Service", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
