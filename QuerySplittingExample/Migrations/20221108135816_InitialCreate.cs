using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuerySplittingExample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "DateOfRegistration", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(743), "Mike", "Miers" },
                    { 2, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(746), "Alex", "Spax" },
                    { 3, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(748), "Bob", "Marley" },
                    { 4, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(750), "Ana", "Mikela" },
                    { 5, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(751), "Maria", "Janovsky" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "DateAdded", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(591), "Data Engineering" },
                    { 2, 1, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(624), "C# Programming" },
                    { 3, 2, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(626), "Social Engineering" },
                    { 4, 3, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(627), "NLP" },
                    { 5, 3, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(629), "Marketing" },
                    { 6, 4, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(631), "Accounting" },
                    { 7, 5, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(633), "Data Mining" },
                    { 8, 5, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(634), "Machine Learning" },
                    { 9, 5, new DateTime(2022, 11, 8, 15, 58, 15, 972, DateTimeKind.Local).AddTicks(636), "Mobile Development" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
