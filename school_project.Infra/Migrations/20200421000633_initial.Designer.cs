﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using school_project.Infra.Context;

namespace school_project.Infra.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200421000633_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("school_backend.Models.ClassTeacher", b =>
                {
                    b.Property<int>("SchoolClassId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("SchoolClassId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassTeacher");
                });

            modelBuilder.Entity("school_backend.Models.SchoolClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("Year")
                        .HasColumnType("int(5)");

                    b.HasKey("Id");

                    b.ToTable("School_Class");
                });

            modelBuilder.Entity("school_backend.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<int>("SchoolClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchoolClassId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("school_backend.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("school_backend.Models.ClassTeacher", b =>
                {
                    b.HasOne("school_backend.Models.SchoolClass", "SchoolClass")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("school_backend.Models.Teacher", "Teacher")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("school_backend.Models.Student", b =>
                {
                    b.HasOne("school_backend.Models.SchoolClass", "SchoolClass")
                        .WithMany("Students")
                        .HasForeignKey("SchoolClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
