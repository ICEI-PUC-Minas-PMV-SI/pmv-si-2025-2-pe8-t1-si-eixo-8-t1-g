using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetshopMiau.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubstituiProdutosPorPacotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "ClientePacoteId",
                table: "Agendamentos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    QuantidadeSessoes = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecoTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValidadeEmDias = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacotes_Servicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientesPacotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataAquisicao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessoesDisponiveis = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    PacoteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesPacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesPacotes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesPacotes_Pacotes_PacoteId",
                        column: x => x.PacoteId,
                        principalTable: "Pacotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_ClientePacoteId",
                table: "Agendamentos",
                column: "ClientePacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesPacotes_ClienteId",
                table: "ClientesPacotes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesPacotes_PacoteId",
                table: "ClientesPacotes",
                column: "PacoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacotes_ServicoId",
                table: "Pacotes",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_ClientesPacotes_ClientePacoteId",
                table: "Agendamentos",
                column: "ClientePacoteId",
                principalTable: "ClientesPacotes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_ClientesPacotes_ClientePacoteId",
                table: "Agendamentos");

            migrationBuilder.DropTable(
                name: "ClientesPacotes");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropIndex(
                name: "IX_Agendamentos_ClientePacoteId",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "ClientePacoteId",
                table: "Agendamentos");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    EstoqueMinimo = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }
    }
}
