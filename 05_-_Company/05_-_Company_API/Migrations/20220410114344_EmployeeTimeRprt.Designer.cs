﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _05___Company_API.Database;

namespace _05___Company_API.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20220410114344_EmployeeTimeRprt")]
    partial class EmployeeTimeRprt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_05___Company_DB.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SecurityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("_05___Company_DB.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("_05___Company_DB.Models.TimeReport", b =>
                {
                    b.Property<int?>("TR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.HasKey("TR_ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("TimeReports");
                });

            modelBuilder.Entity("_05___Company_DB.Models.TimeReport", b =>
                {
                    b.HasOne("_05___Company_DB.Models.Employee", null)
                        .WithMany("TimeReports")
                        .HasForeignKey("EmployeeID");
                });
#pragma warning restore 612, 618
        }
    }
}
