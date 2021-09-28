using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Accounting.Service.Entries.Migrations
{
    public partial class Entries_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Entries");

            migrationBuilder.CreateTable(
                name: "Entry",
                schema: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    EntryIndicatorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntryIndicator",
                schema: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryIndicator", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Entries",
                table: "EntryIndicator",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 10L, "CREDIT" },
                    { 20L, "DEBIT" }
                });
            
            migrationBuilder.AddForeignKey(
                name: "FK_Entry_EntryIndicator", 
                schema: "Entries",
                table: "Entry",
                column: "EntryIndicatorId", 
                principalSchema: "Entries",
                principalTable: "EntryIndicator",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entry",
                schema: "Entries");

            migrationBuilder.DropTable(
                name: "EntryIndicator",
                schema: "Entries");
        }
    }
}
