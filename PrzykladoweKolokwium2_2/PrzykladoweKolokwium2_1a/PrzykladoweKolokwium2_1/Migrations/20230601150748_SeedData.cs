using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrzykladoweKolokwium2_1.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski" },
                    { 2, "Anna", "Nowak" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Adam", "Nowak" },
                    { 2, "Aleksandra", "Wiśniewska" }
                });

            migrationBuilder.InsertData(
                table: "Pastries",
                columns: new[] { "ID", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "Drożdzówka", 3.3m, "A" },
                    { 2, "Babka cytrynowa", 21.23m, "B" },
                    { 3, "Jagodzianka", 7.2m, "A" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "ID", "AcceptedAt", "ClientID", "Comments", "EmployeeID", "FulfilledAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum ...", 2, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lorem ipsum ...", 1, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "OrderPastries",
                columns: new[] { "OrderID", "PastryID", "Amount", "Comments" },
                values: new object[,]
                {
                    { 1, 1, 3, null },
                    { 1, 3, 4, "Lorem ipsum ..." },
                    { 2, 1, 12, null },
                    { 2, 2, 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderPastries",
                keyColumns: new[] { "OrderID", "PastryID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderPastries",
                keyColumns: new[] { "OrderID", "PastryID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderPastries",
                keyColumns: new[] { "OrderID", "PastryID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OrderPastries",
                keyColumns: new[] { "OrderID", "PastryID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pastries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pastries",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pastries",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
