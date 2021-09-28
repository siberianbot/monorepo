using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.DataAccess.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkItemPriority",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemPriority", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WorkItemPriority",
                columns: new[] {"Id", "Name"},
                values: new object[] {10, "Critical"}
            );
            
            migrationBuilder.InsertData(
                table: "WorkItemPriority",
                columns: new[] {"Id", "Name"},
                values: new object[] {20, "High"}
            );

            migrationBuilder.InsertData(
                table: "WorkItemPriority",
                columns: new[] {"Id", "Name"},
                values: new object[] {30, "Medium"}
            );

            migrationBuilder.InsertData(
                table: "WorkItemPriority",
                columns: new[] {"Id", "Name"},
                values: new object[] {40, "Low"}
            );

            migrationBuilder.CreateTable(
                name: "WorkItemType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WorkItemType",
                columns: new[] {"Id", "Name"},
                values: new object[] {10, "Task"}
            );

            migrationBuilder.InsertData(
                table: "WorkItemType",
                columns: new[] {"Id", "Name"},
                values: new object[] {20, "Bug"}
            );

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeId = table.Column<long>(type: "bigint", nullable: false),
                    PriorityId = table.Column<long>(type: "bigint", nullable: true),
                    ParentWorkItemId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_WorkItem_ParentWorkItemId",
                        column: x => x.ParentWorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_WorkItemPriority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "WorkItemPriority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkItem_WorkItemType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "WorkItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_ParentWorkItemId",
                table: "WorkItem",
                column: "ParentWorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_PriorityId",
                table: "WorkItem",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_TypeId",
                table: "WorkItem",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropTable(
                name: "WorkItemPriority");

            migrationBuilder.DropTable(
                name: "WorkItemType");
        }
    }
}
