using Microsoft.EntityFrameworkCore.Migrations;

namespace HallFame.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonId = table.Column<long>(type: "bigint", nullable: false),
                    Level = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => new { x.PersonId, x.Name });
                    table.ForeignKey(
                        name: "FK_Skills_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "DisplayName", "Name" },
                values: new object[,]
                {
                    { 1L, "Alex", "Alexey" },
                    { 2L, "Lera", "Valeria" },
                    { 3L, "Olya", "Olga" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "PersonId", "Level" },
                values: new object[,]
                {
                    { "Data Science", 4L, (byte)10 },
                    { "SQL", 5L, (byte)11 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "PersonId", "Level" },
                values: new object[] { "WPF", 2L, (byte)2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "PersonId", "Level" },
                values: new object[] { "C#", 3L, (byte)5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
