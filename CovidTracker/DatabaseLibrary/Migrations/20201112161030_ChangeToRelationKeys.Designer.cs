﻿// <auto-generated />
using System;
using DatabaseLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseLibrary.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20201112161030_ChangeToRelationKeys")]
    partial class ChangeToRelationKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseLibrary.Citizen", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipalityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("SSN");

                    b.HasIndex("MunicipalityName");

                    b.ToTable("Citizens");
                });

            modelBuilder.Entity("DatabaseLibrary.CitizenTestedAtTestCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CitizenSSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestCenterName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CitizenSSN");

                    b.HasIndex("TestCenterName");

                    b.ToTable("CitizenTestedAtTestCenter");
                });

            modelBuilder.Entity("DatabaseLibrary.CitizenWasAtLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfVisit")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisitedLocationAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitingCitizenSSN")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("VisitedLocationAddress");

                    b.HasIndex("VisitingCitizenSSN");

                    b.ToTable("CitizenWasAtLocation");
                });

            modelBuilder.Entity("DatabaseLibrary.Location", b =>
                {
                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MunicipalityName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Address");

                    b.HasIndex("MunicipalityName");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DatabaseLibrary.Municipality", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("DatabaseLibrary.Nation", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("DatabaseLibrary.TestCenter", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Hours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManagementName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("LocationAddress");

                    b.HasIndex("ManagementName");

                    b.ToTable("TestCenters");
                });

            modelBuilder.Entity("DatabaseLibrary.TestCenterManagement", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("TestCenterManagements");
                });

            modelBuilder.Entity("DatabaseLibrary.Citizen", b =>
                {
                    b.HasOne("DatabaseLibrary.Municipality", "LivesIn")
                        .WithMany("CitizensInMunicipality")
                        .HasForeignKey("MunicipalityName");
                });

            modelBuilder.Entity("DatabaseLibrary.CitizenTestedAtTestCenter", b =>
                {
                    b.HasOne("DatabaseLibrary.Citizen", "TestedCitizen")
                        .WithMany("Tests")
                        .HasForeignKey("CitizenSSN");

                    b.HasOne("DatabaseLibrary.TestCenter", "TestedAt")
                        .WithMany("Tests")
                        .HasForeignKey("TestCenterName");
                });

            modelBuilder.Entity("DatabaseLibrary.CitizenWasAtLocation", b =>
                {
                    b.HasOne("DatabaseLibrary.Location", "VisitedLocation")
                        .WithMany("Visits")
                        .HasForeignKey("VisitedLocationAddress");

                    b.HasOne("DatabaseLibrary.Citizen", "VisitingCitizen")
                        .WithMany("WasAtLocations")
                        .HasForeignKey("VisitingCitizenSSN");
                });

            modelBuilder.Entity("DatabaseLibrary.Location", b =>
                {
                    b.HasOne("DatabaseLibrary.Municipality", "IsIn")
                        .WithMany("LocationsInMunicipality")
                        .HasForeignKey("MunicipalityName");
                });

            modelBuilder.Entity("DatabaseLibrary.TestCenter", b =>
                {
                    b.HasOne("DatabaseLibrary.Location", "PlacedIn")
                        .WithMany("TestCentersAtLocation")
                        .HasForeignKey("LocationAddress");

                    b.HasOne("DatabaseLibrary.TestCenterManagement", "HasManagement")
                        .WithMany("ManagesTestCenters")
                        .HasForeignKey("ManagementName");
                });
#pragma warning restore 612, 618
        }
    }
}