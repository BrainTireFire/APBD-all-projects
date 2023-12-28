using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrzykladoweKolokwium2_2.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnimalClasses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Bird" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Procedures",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum ...", "Endoscopy" },
                    { 2, "Lorem ipsum ...", "Cholecystectomy" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "ID", "AdmissionDate", "AnimalClassID", "Name", "OwnerID" },
                values: new object[] { 1, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AnimalName", 1 });

            migrationBuilder.InsertData(
                table: "ProcedureAnimals",
                columns: new[] { "AnimalID", "Date", "ProcedureID" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnimalClasses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProcedureAnimals",
                keyColumns: new[] { "AnimalID", "Date", "ProcedureID" },
                keyValues: new object[] { 1, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.DeleteData(
                table: "ProcedureAnimals",
                keyColumns: new[] { "AnimalID", "Date", "ProcedureID" },
                keyValues: new object[] { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedures",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnimalClasses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
