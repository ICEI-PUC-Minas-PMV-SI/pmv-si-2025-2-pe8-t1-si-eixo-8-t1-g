using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopMiau.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPorteAndDataNascimentoToPet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Pets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Porte",
                table: "Pets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Porte",
                table: "Pets");
        }
    }
}
