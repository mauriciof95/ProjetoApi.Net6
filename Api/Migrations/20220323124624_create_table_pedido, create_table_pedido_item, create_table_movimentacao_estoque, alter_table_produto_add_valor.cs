using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class create_table_pedidocreate_table_pedido_itemcreate_table_movimentacao_estoquealter_table_produto_add_valor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                schema: "public",
                table: "cliente",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Documento",
                schema: "public",
                table: "cliente",
                newName: "documento");

            migrationBuilder.RenameIndex(
                name: "IX_cliente_Documento",
                schema: "public",
                table: "cliente",
                newName: "IX_cliente_documento");

            migrationBuilder.AlterColumn<long>(
                name: "categoria_id",
                schema: "public",
                table: "produto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 3)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AddColumn<decimal>(
                name: "valor",
                schema: "public",
                table: "produto",
                type: "numeric",
                nullable: false,
                defaultValue: 0m)
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateTable(
                name: "movimentacao_estoque",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    tipo_movimento = table.Column<string>(type: "text", nullable: false),
                    motivo_movimento = table.Column<string>(type: "text", nullable: false),
                    produto_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimentacao_estoque", x => x.id);
                    table.ForeignKey(
                        name: "FK_movimentacao_estoque_produto_produto_id",
                        column: x => x.produto_id,
                        principalSchema: "public",
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendedor",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    documento = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_pedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status_pedido = table.Column<string>(type: "text", nullable: false),
                    cliente_id = table.Column<long>(type: "bigint", nullable: false),
                    vendedor_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_cliente_id",
                        column: x => x.cliente_id,
                        principalSchema: "public",
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_vendedor_cliente_id",
                        column: x => x.cliente_id,
                        principalSchema: "public",
                        principalTable: "vendedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido_item",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    valor_pago = table.Column<decimal>(type: "numeric", nullable: false),
                    quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    pedido_id = table.Column<long>(type: "bigint", nullable: false),
                    produto_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_item_pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalSchema: "public",
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_item_produto_produto_id",
                        column: x => x.produto_id,
                        principalSchema: "public",
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimentacao_estoque_produto_id",
                schema: "public",
                table: "movimentacao_estoque",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cliente_id",
                schema: "public",
                table: "pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_pedido_id",
                schema: "public",
                table: "pedido_item",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_produto_id",
                schema: "public",
                table: "pedido_item",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_vendedor_documento",
                schema: "public",
                table: "vendedor",
                column: "documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacao_estoque",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pedido_item",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pedido",
                schema: "public");

            migrationBuilder.DropTable(
                name: "vendedor",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "valor",
                schema: "public",
                table: "produto");

            migrationBuilder.RenameColumn(
                name: "nome",
                schema: "public",
                table: "cliente",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "documento",
                schema: "public",
                table: "cliente",
                newName: "Documento");

            migrationBuilder.RenameIndex(
                name: "IX_cliente_documento",
                schema: "public",
                table: "cliente",
                newName: "IX_cliente_Documento");

            migrationBuilder.AlterColumn<long>(
                name: "categoria_id",
                schema: "public",
                table: "produto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 3);
        }
    }
}
