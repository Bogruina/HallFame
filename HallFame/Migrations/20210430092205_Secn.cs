using Microsoft.EntityFrameworkCore.Migrations;

namespace HallFame.Migrations
{
    public partial class Secn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "WPF", 2L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "C#", 3L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Data Science", 4L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "SQL", 5L });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "PersonId", "Level" },
                values: new object[,]
                {
                    { "WPF", 1L, (byte)2 },
                    { "C#", 2L, (byte)5 },
                    { "Data Science", 3L, (byte)10 },
                    { "SQL", 1L, (byte)11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "SQL", 1L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "WPF", 1L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "C#", 2L });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumns: new[] { "Name", "PersonId" },
                keyValues: new object[] { "Data Science", 3L });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Name", "PersonId", "Level" },
                values: new object[,]
                {
                    { "WPF", 2L, (byte)2 },
                    { "C#", 3L, (byte)5 },
                    { "Data Science", 4L, (byte)10 },
                    { "SQL", 5L, (byte)11 }
                });
        }
    }
}
