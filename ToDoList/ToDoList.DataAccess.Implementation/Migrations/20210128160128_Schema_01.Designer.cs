﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoList.DataAccess.Implementation.SqlServer;

namespace ToDoList.DataAccess.Implementation.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20210128160128_Schema_01")]
    partial class Schema_01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ToDoList.Models.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("ToDoList.Models.Task", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int?>("ActualTime")
                        .HasColumnType("int");

                    b.Property<string>("AssignedTo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("CreationDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long?>("ParentTaskId")
                        .HasColumnType("bigint");

                    b.Property<int>("RemainingTime")
                        .HasColumnType("int");

                    b.Property<long?>("StatusId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentTaskId");

                    b.HasIndex("StatusId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("ToDoList.Models.Task", b =>
                {
                    b.HasOne("ToDoList.Models.Task", "ParentTask")
                        .WithMany("ChildTasks")
                        .HasForeignKey("ParentTaskId");

                    b.HasOne("ToDoList.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentTask");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ToDoList.Models.Task", b =>
                {
                    b.Navigation("ChildTasks");
                });
#pragma warning restore 612, 618
        }
    }
}