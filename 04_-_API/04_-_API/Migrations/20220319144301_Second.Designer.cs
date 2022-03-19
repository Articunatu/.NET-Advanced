﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _04___API.Models;

namespace _04___API.Migrations
{
    [DbContext(typeof(WebDbContext))]
    [Migration("20220319144301_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_04___API.Models.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestID");

                    b.HasIndex("PersonID");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("_04___API.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("_04___API.Models.WebLink", b =>
                {
                    b.Property<int>("WebID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<string>("LinkURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("WebID");

                    b.HasIndex("InterestID");

                    b.HasIndex("PersonID");

                    b.ToTable("WebLinks");
                });

            modelBuilder.Entity("_04___API.Models.Interest", b =>
                {
                    b.HasOne("_04___API.Models.Person", null)
                        .WithMany("Interests")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("_04___API.Models.WebLink", b =>
                {
                    b.HasOne("_04___API.Models.Interest", "Interest")
                        .WithMany()
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_04___API.Models.Person", "Person")
                        .WithMany("WebLinks")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
