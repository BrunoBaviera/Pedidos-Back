using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedidos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Pedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    pedidoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeCliente = table.Column<string>(type: "varchar(60)", nullable: false),
                    EmailCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datacriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.pedidoid);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    produtoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeProduto = table.Column<string>(type: "varchar(20)", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.produtoid);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    itempedidoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    pedidoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    produtoid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantidade = table.Column<decimal>(type: "numeric(14,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.itempedidoid);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedido_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "pedidoid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produto",
                        principalColumn: "produtoid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_pedidoid",
                table: "ItensPedido",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_produtoid",
                table: "ItensPedido",
                column: "produtoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
