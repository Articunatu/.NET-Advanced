using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _05___Company_API.Migrations
{
    public partial class IntWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeekDate",
                table: "TimeReports");

            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "TimeReports",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "TimeReports");

            migrationBuilder.AddColumn<DateTime>(
                name: "WeekDate",
                table: "TimeReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
