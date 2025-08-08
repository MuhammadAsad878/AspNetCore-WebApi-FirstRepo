using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstApiProj.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "Gpa", "InActive", "Name", "Section" },
                values: new object[,]
                {
                    { 1, "Pakpattan", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.22f, null, "Muhammad Asad", "MB" },
                    { 2, "Lahore", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.75f, null, "Nadim Jawad", "MA" },
                    { 3, "Karachi", new DateTime(2025, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9f, null, "Ali Ahmed", "MB" },
                    { 4, "FortAbbas", new DateTime(2025, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.45f, null, "Hassan Raza", "MC" },
                    { 5, "Multan", new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.6f, null, "Ayesha Malik", "MA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
