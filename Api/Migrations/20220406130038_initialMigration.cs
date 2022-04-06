using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    documento = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vendedor",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: false),
                    documento = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendedor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    categoria_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil_permissao",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    permissao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    perfil_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_permissao", x => x.id);
                    table.ForeignKey(
                        name: "FK_perfil_permissao_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    senha = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    refresh_token = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    refresh_token_expiry_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    perfil_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_pedido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    data_pedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
                        principalTable: "cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_vendedor_vendedor_id",
                        column: x => x.vendedor_id,
                        principalTable: "vendedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimentacao_estoque",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    motivo_movimento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tipo_movimento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
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
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    valor_unitario_pago = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    produto_id = table.Column<long>(type: "bigint", nullable: false),
                    pedido_id = table.Column<long>(type: "bigint", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_item", x => x.id);
                    table.ForeignKey(
                        name: "FK_pedido_item_pedido_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_item_produto_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "perfil",
                columns: new[] { "id", "ativo", "data_criacao", "data_edicao", "descricao" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2022, 4, 6, 10, 0, 37, 835, DateTimeKind.Local).AddTicks(6472), null, "Admin" },
                    { 2L, true, new DateTime(2022, 4, 6, 10, 0, 37, 835, DateTimeKind.Local).AddTicks(6484), null, "Colaborador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_documento",
                table: "cliente",
                column: "documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimentacao_estoque_produto_id",
                table: "movimentacao_estoque",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cliente_id",
                table: "pedido",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_vendedor_id",
                table: "pedido",
                column: "vendedor_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_pedido_id",
                table: "pedido_item",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_item_produto_id",
                table: "pedido_item",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_perfil_permissao_perfil_id",
                table: "perfil_permissao",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "IX_produto_categoria_id",
                table: "produto",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_id",
                table: "usuario",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "IX_vendedor_documento",
                table: "vendedor",
                column: "documento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimentacao_estoque");

            migrationBuilder.DropTable(
                name: "pedido_item");

            migrationBuilder.DropTable(
                name: "perfil_permissao");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "vendedor");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
