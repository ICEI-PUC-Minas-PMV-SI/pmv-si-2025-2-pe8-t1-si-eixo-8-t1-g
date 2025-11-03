using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopMiau.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadoDataPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Agendamentos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Agendamentos");
        }
    }
}
