﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issues.Infrastructure.Migrations
{
    public partial class SomeMigrationaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusFlowId1",
                table: "TypesOfIssueInTypeOfGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfGroupOfIssuesId1",
                table: "TypesOfIssueInTypeOfGroups",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusFlowId1",
                table: "TypesOfIssueInTypeOfGroups");

            migrationBuilder.DropColumn(
                name: "TypeOfGroupOfIssuesId1",
                table: "TypesOfIssueInTypeOfGroups");
        }
    }
}
