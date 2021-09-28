using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.DataAccess.Implementation.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RemainingTime = table.Column<int>(type: "int", nullable: false),
                    ActualTime = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentTaskId = table.Column<long>(type: "bigint", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Task_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_ParentTaskId",
                table: "Task",
                column: "ParentTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusId",
                table: "Task",
                column: "StatusId");

            migrationBuilder.InsertData("Status", new[] {"Id", "Code"}, new object[] {10, "NEW"});
            migrationBuilder.InsertData("Status", new[] {"Id", "Code"}, new object[] {20, "INPROGRESS"});
            migrationBuilder.InsertData("Status", new[] {"Id", "Code"}, new object[] {30, "CANCELED"});
            migrationBuilder.InsertData("Status", new[] {"Id", "Code"}, new object[] {40, "COMPLETED"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
