using Microsoft.EntityFrameworkCore.Migrations;

namespace Employees.Migrations
{
    public partial class AddListInModelForFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Employees_EmployeeId",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_EmployeeId",
                table: "Children");

            migrationBuilder.CreateTable(
                name: "ChildrenEmployee",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenEmployee", x => new { x.ChildrenId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ChildrenEmployee_Children_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildrenEmployee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenEmployee_EmployeeId",
                table: "ChildrenEmployee",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildrenEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Children_EmployeeId",
                table: "Children",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Employees_EmployeeId",
                table: "Children",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
