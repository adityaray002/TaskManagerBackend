using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initDb1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskMappings_EmpId",
                table: "EmployeeTaskMappings",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskMappings_Employees_EmpId",
                table: "EmployeeTaskMappings",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "Emp_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskMappings_Employees_EmpId",
                table: "EmployeeTaskMappings");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTaskMappings_EmpId",
                table: "EmployeeTaskMappings");
        }
    }
}
