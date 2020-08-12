using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.API.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Title", "Genre" },
                values: new object[,]
                {
                    { 1, "Charles Dickens", "A great read.", "Great Expectations", "" },
                    { 2, "George Orwell", "", "Animal Farm","" },
                    { 3, "Dashiell Hammett", "", "The Maltese Falcon","" },
                    { 4, "E M Forster", "A great view", "A Room with a View","" },
                    { 5, "Harper Lee", "", "To Kill a Mockingbird","" },
                    { 6, "George Orwell","","1984","Dystopian Fiction" },
                    { 7, "Charles Dickens", "","A Christmas Carol","Novel" },
                    { 8, "Oscar Wilde","","The Picture of Dorian Gray","Novel" },
                    { 9, "Ray Bradbury","","Fahrenheit 451","Dystopian Fiction" },
                    {10, "Jack London","","The Call of the Wild","Adventure Fiction"},
                    {11, "Agatha Christie","","Murder on the Orient Express","Crime Fiction"}
                });

            migrationBuilder.InsertData(
                table: "Quotations",
                columns: new[] { "Id", "BookId", "Notes", "Quote" },
                values: new object[,]
                {
                    { 1, 1, "", "You are in every line I have ever read." },
                    { 2, 1, "", "Spring is the time of year when it is summer in the sun and winter in the shade." },
                    { 3, 2, "", "All animals are equal, but some animals are more equal than others." },
                    { 4, 2, "", "Four legs good, two legs bad." },
                    { 5, 2, "", "This work was strictly voluntary, but any animal who absented himself from it would have his rations reduced by half." },
                    { 6, 3, "", " I wanted it, and I'm not a man that's easily discouraged when he wants something." },
                    { 7, 3, "", "You know how to do things ... you'll land on your feet in the end." },
                    { 8, 3, "", "The cheaper the crook, the gaudier the patter." },
                    { 9, 4, "", "Life is easy to chronicle, but bewildering to practice." },
                    { 10, 4, "", "Of course he despised the world as a whole; every thoughtful man should; it is almost a test of refinement." },
                    { 11, 4, "", "The world is certainly full of beautiful things, if only I could come across them." },
                    { 12, 5, "", "You never really understand a person until you consider things from his point of view... Until you climb inside of his skin and walk around in it." },
                    { 13, 5, "", "People generally see what they look for, and hear what they listen for." },
                    { 14, 5, "", "Lawyers, I suppose were once children, too." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
