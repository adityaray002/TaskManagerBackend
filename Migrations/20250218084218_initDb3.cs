using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskMappings_Tasks_TaskId",
                table: "EmployeeTaskMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatusMappings_Tasks_TaskId",
                table: "TaskStatusMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTagMappings_Tasks_TaskId",
                table: "TaskTagMappings");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.CreateTable(
                name: "Taskss",
                columns: table => new
                {
                    Task_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Task_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taskss", x => x.Task_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskMappings_Taskss_TaskId",
                table: "EmployeeTaskMappings",
                column: "TaskId",
                principalTable: "Taskss",
                principalColumn: "Task_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatusMappings_Taskss_TaskId",
                table: "TaskStatusMappings",
                column: "TaskId",
                principalTable: "Taskss",
                principalColumn: "Task_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTagMappings_Taskss_TaskId",
                table: "TaskTagMappings",
                column: "TaskId",
                principalTable: "Taskss",
                principalColumn: "Task_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTaskMappings_Taskss_TaskId",
                table: "EmployeeTaskMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatusMappings_Taskss_TaskId",
                table: "TaskStatusMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTagMappings_Taskss_TaskId",
                table: "TaskTagMappings");

            migrationBuilder.DropTable(
                name: "Taskss");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Task_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task_Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Task_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTaskMappings_Tasks_TaskId",
                table: "EmployeeTaskMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Task_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatusMappings_Tasks_TaskId",
                table: "TaskStatusMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Task_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTagMappings_Tasks_TaskId",
                table: "TaskTagMappings",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Task_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
