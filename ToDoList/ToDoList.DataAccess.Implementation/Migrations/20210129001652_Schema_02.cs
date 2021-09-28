using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.DataAccess.Implementation.Migrations
{
    public partial class Schema_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "Task",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "Task");
        }
    }
}
