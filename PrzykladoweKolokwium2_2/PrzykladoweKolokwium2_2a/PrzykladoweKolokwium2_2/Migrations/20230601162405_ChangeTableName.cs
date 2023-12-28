using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzykladoweKolokwium2_2.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AnimalClasses_AnimalClassID",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owners_OwnerID",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureAnimals_Animals_AnimalID",
                table: "ProcedureAnimals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcedureAnimals_Procedures_ProcedureID",
                table: "ProcedureAnimals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcedureAnimals",
                table: "ProcedureAnimals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalClasses",
                table: "AnimalClasses");

            migrationBuilder.RenameTable(
                name: "Procedures",
                newName: "Procedure");

            migrationBuilder.RenameTable(
                name: "ProcedureAnimals",
                newName: "Procedure_Animal");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "Owner");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Animal");

            migrationBuilder.RenameTable(
                name: "AnimalClasses",
                newName: "Animal_Class");

            migrationBuilder.RenameIndex(
                name: "IX_ProcedureAnimals_AnimalID",
                table: "Procedure_Animal",
                newName: "IX_Procedure_Animal_AnimalID");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_OwnerID",
                table: "Animal",
                newName: "IX_Animal_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_AnimalClassID",
                table: "Animal",
                newName: "IX_Animal_AnimalClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedure_Animal",
                table: "Procedure_Animal",
                columns: new[] { "ProcedureID", "AnimalID", "Date" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owner",
                table: "Owner",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animal",
                table: "Animal",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animal_Class",
                table: "Animal_Class",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Animal_Class_AnimalClassID",
                table: "Animal",
                column: "AnimalClassID",
                principalTable: "Animal_Class",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Owner_OwnerID",
                table: "Animal",
                column: "OwnerID",
                principalTable: "Owner",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Animal_Animal_AnimalID",
                table: "Procedure_Animal",
                column: "AnimalID",
                principalTable: "Animal",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedure_Animal_Procedure_ProcedureID",
                table: "Procedure_Animal",
                column: "ProcedureID",
                principalTable: "Procedure",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Animal_Class_AnimalClassID",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Owner_OwnerID",
                table: "Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Animal_Animal_AnimalID",
                table: "Procedure_Animal");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedure_Animal_Procedure_ProcedureID",
                table: "Procedure_Animal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedure_Animal",
                table: "Procedure_Animal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Procedure",
                table: "Procedure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owner",
                table: "Owner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal_Class",
                table: "Animal_Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animal",
                table: "Animal");

            migrationBuilder.RenameTable(
                name: "Procedure_Animal",
                newName: "ProcedureAnimals");

            migrationBuilder.RenameTable(
                name: "Procedure",
                newName: "Procedures");

            migrationBuilder.RenameTable(
                name: "Owner",
                newName: "Owners");

            migrationBuilder.RenameTable(
                name: "Animal_Class",
                newName: "AnimalClasses");

            migrationBuilder.RenameTable(
                name: "Animal",
                newName: "Animals");

            migrationBuilder.RenameIndex(
                name: "IX_Procedure_Animal_AnimalID",
                table: "ProcedureAnimals",
                newName: "IX_ProcedureAnimals_AnimalID");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_OwnerID",
                table: "Animals",
                newName: "IX_Animals_OwnerID");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_AnimalClassID",
                table: "Animals",
                newName: "IX_Animals_AnimalClassID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcedureAnimals",
                table: "ProcedureAnimals",
                columns: new[] { "ProcedureID", "AnimalID", "Date" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Procedures",
                table: "Procedures",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalClasses",
                table: "AnimalClasses",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AnimalClasses_AnimalClassID",
                table: "Animals",
                column: "AnimalClassID",
                principalTable: "AnimalClasses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owners_OwnerID",
                table: "Animals",
                column: "OwnerID",
                principalTable: "Owners",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureAnimals_Animals_AnimalID",
                table: "ProcedureAnimals",
                column: "AnimalID",
                principalTable: "Animals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcedureAnimals_Procedures_ProcedureID",
                table: "ProcedureAnimals",
                column: "ProcedureID",
                principalTable: "Procedures",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
