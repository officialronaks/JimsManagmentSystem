﻿// <auto-generated />
using System;
using Jims_Managment_System_Or.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jims_Managment_System_Or.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jims_Managment_System_Or.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Jims_Managment_System_Or.Course", b =>
                {
                    b.Property<int>("Cid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cid"));

                    b.Property<decimal>("Cfees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("duration")
                        .HasColumnType("int");

                    b.Property<int>("totalstudents")
                        .HasColumnType("int");

                    b.HasKey("Cid");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Jims_Managment_System_Or.Faculty", b =>
                {
                    b.Property<int>("Fid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Fid"));

                    b.Property<int>("Cid")
                        .HasColumnType("int");

                    b.Property<int?>("CourseCid")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Fid");

                    b.HasIndex("CourseCid");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Jims_Managment_System_Or.Students", b =>
                {
                    b.Property<int>("Sid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Sid"));

                    b.Property<int>("Attendance")
                        .HasColumnType("int");

                    b.Property<int>("Cid")
                        .HasColumnType("int");

                    b.Property<int?>("CourseCid")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("totalpercentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Sid");

                    b.HasIndex("CourseCid");

                    b.ToTable("Studentss");
                });

            modelBuilder.Entity("Jims_Managment_System_Or.Faculty", b =>
                {
                    b.HasOne("Jims_Managment_System_Or.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCid");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Jims_Managment_System_Or.Students", b =>
                {
                    b.HasOne("Jims_Managment_System_Or.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseCid");

                    b.Navigation("Course");
                });
#pragma warning restore 612, 618
        }
    }
}
