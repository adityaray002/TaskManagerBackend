using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Emp_Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Status_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Tag_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Tag_Id);
                });

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

            migrationBuilder.CreateTable(
                name: "EmployeeTaskMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    TasksTask_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaskMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskMappings_Taskss_TasksTask_Id",
                        column: x => x.TasksTask_Id,
                        principalTable: "Taskss",
                        principalColumn: "Task_Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskStatusMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TasksTask_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatusMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskStatusMappings_Taskss_TasksTask_Id",
                        column: x => x.TasksTask_Id,
                        principalTable: "Taskss",
                        principalColumn: "Task_Id");
                });

            migrationBuilder.CreateTable(
                name: "TaskTagMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    TasksTask_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTagMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskTagMappings_Taskss_TasksTask_Id",
                        column: x => x.TasksTask_Id,
                        principalTable: "Taskss",
                        principalColumn: "Task_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskMappings_TasksTask_Id",
                table: "EmployeeTaskMappings",
                column: "TasksTask_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatusMappings_TasksTask_Id",
                table: "TaskStatusMappings",
                column: "TasksTask_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTagMappings_TasksTask_Id",
                table: "TaskTagMappings",
                column: "TasksTask_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeTaskMappings");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TaskStatusMappings");

            migrationBuilder.DropTable(
                name: "TaskTagMappings");

            migrationBuilder.DropTable(
                name: "Taskss");
        }
    }
}
