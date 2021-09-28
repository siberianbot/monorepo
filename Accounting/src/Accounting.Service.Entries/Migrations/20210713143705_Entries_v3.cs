using Microsoft.EntityFrameworkCore.Migrations;

namespace Accounting.Service.Entries.Migrations
{
    public partial class Entries_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Entry_Date",
                schema: "Entries",
                table: "Entry",
                column: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entry_Date",
                schema: "Entries",
                table: "Entry");
        }
    }
}
