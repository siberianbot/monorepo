// <auto-generated />
using System;
using Accounting.Service.Entries.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Accounting.Service.Entries.Migrations
{
    [DbContext(typeof(EntriesContext))]
    [Migration("20210713143352_Entries_v2")]
    partial class Entries_v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Entries")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Accounting.DataAccess.Extensions.Internal.CodeLookupModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("EntryIndicator");

                    b.HasData(
                        new
                        {
                            Id = 10L,
                            Code = "CREDIT"
                        },
                        new
                        {
                            Id = 20L,
                            Code = "DEBIT"
                        });
                });

            modelBuilder.Entity("Accounting.Service.Entries.DomainModel.Entry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal?>("Amount")
                        .IsRequired()
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<long?>("EntryIndicatorId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Entry");
                });
#pragma warning restore 612, 618
        }
    }
}
