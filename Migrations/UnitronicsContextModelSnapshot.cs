﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using unitronicsWebApi;
using unitronicsWebApi.Model;

namespace unitronicsWebApi.Migrations
{
    [DbContext(typeof(UnitronicsContext))]
    partial class UnitronicsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("unitronicsWebApi.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("unitronicsWebApi.Table", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CarId")
                        .HasColumnName("carID")
                        .HasMaxLength(10);

                    b.Property<int?>("Length")
                        .HasColumnName("length");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });
#pragma warning restore 612, 618
        }
    }
}
