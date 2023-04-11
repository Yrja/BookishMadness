using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookishMadness.DAL.Migrations
{
    public partial class Add_Book_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PagesCount = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Name", "PagesCount", "Status" },
                values: new object[] { new Guid("163c0025-33f7-46aa-8069-95b53b37df86"), "L. J. Shenn", "Description", null, "Pretty reckless", 0, "WantToRead" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Name", "PagesCount", "Status" },
                values: new object[] { new Guid("17f8b524-7d55-4201-9c7c-a7fad54845ec"), "J. R. R. Tolkien", "Description", null, "Lord of the ring", 0, "Reading" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Name", "PagesCount", "Status" },
                values: new object[] { new Guid("4583cf5c-402f-410a-9cdb-309d8b498774"), "Stephanie Garber", "Description", null, "Caraval", 0, "Reading" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
