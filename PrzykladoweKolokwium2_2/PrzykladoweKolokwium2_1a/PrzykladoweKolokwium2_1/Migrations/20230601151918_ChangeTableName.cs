using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzykladoweKolokwium2_1.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPastries_Orders_OrderID",
                table: "OrderPastries");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPastries_Pastries_PastryID",
                table: "OrderPastries");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPastries",
                table: "OrderPastries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Pastries",
                newName: "Pastry");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderPastries",
                newName: "OrderPastry");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployeeID",
                table: "Order",
                newName: "IX_Order_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientID",
                table: "Order",
                newName: "IX_Order_ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPastries_PastryID",
                table: "OrderPastry",
                newName: "IX_OrderPastry_PastryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPastry",
                table: "OrderPastry",
                columns: new[] { "OrderID", "PastryID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order",
                column: "ClientID",
                principalTable: "Client",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPastry_Order_OrderID",
                table: "OrderPastry",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPastry_Pastry_PastryID",
                table: "OrderPastry",
                column: "PastryID",
                principalTable: "Pastry",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Client_ClientID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPastry_Order_OrderID",
                table: "OrderPastry");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPastry_Pastry_PastryID",
                table: "OrderPastry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pastry",
                table: "Pastry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPastry",
                table: "OrderPastry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Pastry",
                newName: "Pastries");

            migrationBuilder.RenameTable(
                name: "OrderPastry",
                newName: "OrderPastries");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPastry_PastryID",
                table: "OrderPastries",
                newName: "IX_OrderPastries_PastryID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_EmployeeID",
                table: "Orders",
                newName: "IX_Orders_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientID",
                table: "Orders",
                newName: "IX_Orders_ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pastries",
                table: "Pastries",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPastries",
                table: "OrderPastries",
                columns: new[] { "OrderID", "PastryID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPastries_Orders_OrderID",
                table: "OrderPastries",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPastries_Pastries_PastryID",
                table: "OrderPastries",
                column: "PastryID",
                principalTable: "Pastries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientID",
                table: "Orders",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeID",
                table: "Orders",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
