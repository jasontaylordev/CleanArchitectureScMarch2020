using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaWorkshop.Infrastructure.Persistence.Migrations
{
    public partial class AuditableEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TodoLists",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "TodoLists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TodoLists",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "TodoLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "TodoItems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TodoItems",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "TodoItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "TodoItems");
        }
    }
}
