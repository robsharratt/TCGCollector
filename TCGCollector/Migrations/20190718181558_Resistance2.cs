using Microsoft.EntityFrameworkCore.Migrations;

namespace TCGCollector.Migrations
{
    public partial class Resistance2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCardResistances_Resistance_ResistanceID",
                table: "PokemonCardResistances");

            migrationBuilder.DropForeignKey(
                name: "FK_Resistance_EnergyTypes_EnergyTypeID",
                table: "Resistance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resistance",
                table: "Resistance");

            migrationBuilder.RenameTable(
                name: "Resistance",
                newName: "Resistances");

            migrationBuilder.RenameIndex(
                name: "IX_Resistance_EnergyTypeID",
                table: "Resistances",
                newName: "IX_Resistances_EnergyTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resistances",
                table: "Resistances",
                column: "ResistanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCardResistances_Resistances_ResistanceID",
                table: "PokemonCardResistances",
                column: "ResistanceID",
                principalTable: "Resistances",
                principalColumn: "ResistanceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resistances_EnergyTypes_EnergyTypeID",
                table: "Resistances",
                column: "EnergyTypeID",
                principalTable: "EnergyTypes",
                principalColumn: "EnergyTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonCardResistances_Resistances_ResistanceID",
                table: "PokemonCardResistances");

            migrationBuilder.DropForeignKey(
                name: "FK_Resistances_EnergyTypes_EnergyTypeID",
                table: "Resistances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resistances",
                table: "Resistances");

            migrationBuilder.RenameTable(
                name: "Resistances",
                newName: "Resistance");

            migrationBuilder.RenameIndex(
                name: "IX_Resistances_EnergyTypeID",
                table: "Resistance",
                newName: "IX_Resistance_EnergyTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resistance",
                table: "Resistance",
                column: "ResistanceID");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonCardResistances_Resistance_ResistanceID",
                table: "PokemonCardResistances",
                column: "ResistanceID",
                principalTable: "Resistance",
                principalColumn: "ResistanceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resistance_EnergyTypes_EnergyTypeID",
                table: "Resistance",
                column: "EnergyTypeID",
                principalTable: "EnergyTypes",
                principalColumn: "EnergyTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
