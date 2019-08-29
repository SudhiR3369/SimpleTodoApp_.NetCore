using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class TodoTaskUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "TodoTasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskDate",
                table: "TodoTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "TaskDate",
                table: "TodoTasks");
        }
    }
}
