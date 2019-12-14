using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnionArchitecture.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    isActive = table.Column<bool>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Task_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    TaskStatusId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Color = table.Column<string>(maxLength: 7, nullable: true),
                    TaskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.TaskStatusId);
                    table.ForeignKey(
                        name: "FK_TaskStatus_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CustomerId",
                table: "Tasks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskStatus_TaskId",
                table: "TaskStatus",
                column: "TaskId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
