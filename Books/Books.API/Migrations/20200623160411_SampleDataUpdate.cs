using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.API.Migrations
{
    public partial class SampleDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Genre",
                value: "Political Satire");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Genre",
                value: "Crime Fiction");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Genre",
                value: "Novel");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Genre",
                value: "Bildungsroman");

            migrationBuilder.UpdateData(
              table: "Books",
              keyColumn: "Id",
              keyValue: 1,
              column: "Genre",
              value: "Novel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Genre",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Genre",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Genre",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Genre",
                value: null);

            migrationBuilder.UpdateData(
               table: "Books",
               keyColumn: "Id",
               keyValue: 1,
               column: "Genre",
               value: null);
        }
    }
}
