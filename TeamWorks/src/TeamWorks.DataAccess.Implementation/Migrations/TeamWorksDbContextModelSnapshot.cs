﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamWorks.DataAccess.Implementation;

namespace TeamWorks.DataAccess.Implementation.Migrations
{
    [DbContext(typeof(TeamWorksDbContext))]
    partial class TeamWorksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TeamWorks.DomainModel.Scope", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ParentScopeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentScopeId");

                    b.ToTable("Scope");
                });

            modelBuilder.Entity("TeamWorks.DomainModel.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TeamWorks.DomainModel.WorkItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long?>("ScopeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StatusId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ScopeId");

                    b.HasIndex("StatusId");

                    b.ToTable("WorkItem");
                });

            modelBuilder.Entity("TeamWorks.DomainModel.Scope", b =>
                {
                    b.HasOne("TeamWorks.DomainModel.Scope", "ParentScope")
                        .WithMany("ChildScopes")
                        .HasForeignKey("ParentScopeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TeamWorks.DomainModel.WorkItem", b =>
                {
                    b.HasOne("TeamWorks.DomainModel.Scope", "Scope")
                        .WithMany()
                        .HasForeignKey("ScopeId");

                    b.HasOne("TeamWorks.DomainModel.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
