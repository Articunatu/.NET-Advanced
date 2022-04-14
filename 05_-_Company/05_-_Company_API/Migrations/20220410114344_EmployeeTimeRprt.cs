using Microsoft.EntityFrameworkCore.Migrations;

namespace _05___Company_API.Migrations
{
    public partial class EmployeeTimeRprt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeID",
                table: "TimeReports",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeReports_Employees_EmployeeID",
                table: "TimeReports",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeReports_Employees_EmployeeID",
                table: "TimeReports");

            migrationBuilder.DropIndex(
                name: "IX_TimeReports_EmployeeID",
                table: "TimeReports");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
