using Microsoft.EntityFrameworkCore.Migrations;
using TeamWorks.DataAccess.Implementation.Extensions;
using TeamWorks.DomainModel;

namespace TeamWorks.DataAccess.Implementation.Migrations
{
    public partial class Schema_v1_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddStatus(WorkItemStatus.New);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RemoveStatus(WorkItemStatus.New);
        }
    }
}
