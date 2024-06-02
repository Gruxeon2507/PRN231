﻿// <auto-generated />
using Assignment02.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment02.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment02.Models.MedicalFacility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"), 1L, 1);

                    b.Property<string>("FacilityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("NoDoctors")
                        .HasColumnType("int");

                    b.Property<int>("NoStaffs")
                        .HasColumnType("int");

                    b.Property<bool>("PrivateFacility")
                        .HasColumnType("bit");

                    b.HasKey("FacilityId")
                        .HasName("PK_MedicalfacilityId");

                    b.ToTable("MedicalFacility", (string)null);
                });

            modelBuilder.Entity("Assignment02.Models.ServicePriceList", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<int>("ServiceLevel")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ServiceId")
                        .HasName("PK_SerivceId");

                    b.ToTable("ServicePriceList", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
