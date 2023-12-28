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
                table: "Animal_Class",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Mammal" },
                    { 2, "Bird" }
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Procedure",
                columns: new[] { "ID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum ...", "Endoscopy" },
                    { 2, "Lorem ipsum ...", "Cholecystectomy" }
                });

            migrationBuilder.InsertData(
                table: "Animal",
                columns: new[] { "ID", "AdmissionDate", "AnimalClassID", "Name", "OwnerID" },
                values: new object[] { 1, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "AnimalName", 1 });

            migrationBuilder.InsertData(
                table: "Procedure_Animal",
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
                table: "Animal_Class",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Procedure_Animal",
                keyColumns: new[] { "AnimalID", "Date", "ProcedureID" },
                keyValues: new object[] { 1, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.DeleteData(
                table: "Procedure_Animal",
                keyColumns: new[] { "AnimalID", "Date", "ProcedureID" },
                keyValues: new object[] { 1, new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.DeleteData(
                table: "Animal",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedure",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Procedure",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animal_Class",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
