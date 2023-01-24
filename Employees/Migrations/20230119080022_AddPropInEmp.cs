using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees.Migrations
{
    public partial class AddPropInEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildrenId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildrenId",
                table: "Employees");
        }
    }
}
