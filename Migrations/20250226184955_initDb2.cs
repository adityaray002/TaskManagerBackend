using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_Manager_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TaskTagMappings_TagId",
                table: "TaskTagMappings",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatusMappings_StatusId",
                table: "TaskStatusMappings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskStatusMappings_Statuses_StatusId",
                table: "TaskStatusMappings",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Status_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskTagMappings_Tags_TagId",
                table: "TaskTagMappings",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Tag_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskStatusMappings_Statuses_StatusId",
                table: "TaskStatusMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskTagMappings_Tags_TagId",
                table: "TaskTagMappings");

            migrationBuilder.DropIndex(
                name: "IX_TaskTagMappings_TagId",
                table: "TaskTagMappings");

            migrationBuilder.DropIndex(
                name: "IX_TaskStatusMappings_StatusId",
                table: "TaskStatusMappings");
        }
    }
}
