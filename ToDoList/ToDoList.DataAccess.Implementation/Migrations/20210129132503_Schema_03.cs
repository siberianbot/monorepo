using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.DataAccess.Implementation.Migrations
{
    public partial class Schema_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Task",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Task",
                newName: "Name");
        }
    }
}
