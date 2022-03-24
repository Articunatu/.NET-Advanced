using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_EasyAPi.Migrations
{
    public partial class Finally : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Class = table.Column<string>(nullable: true),
                    Type1 = table.Column<int>(nullable: false),
                    Type2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "ID", "Class", "Name", "Type1", "Type2" },
                values: new object[,]
                {
                    { 1, "Physical Attacker", "Forest", 1, 0 },
                    { 2, "Special Attacker", "City", 8, 5 },
                    { 3, "Physical Wall", "Mountain", 7, 2 },
                    { 4, "Special Attacker", "Palace", 3, 0 },
                    { 5, "Speical Wall", "Heaven", 11, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
