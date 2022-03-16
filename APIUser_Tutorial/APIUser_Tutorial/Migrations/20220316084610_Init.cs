using Microsoft.EntityFrameworkCore.Migrations;

namespace APIUser_Tutorial.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Name" },
                values: new object[] { 109, "Scar" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Name" },
                values: new object[] { 110, "Toph" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Name" },
                values: new object[] { 111, "Blur" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
