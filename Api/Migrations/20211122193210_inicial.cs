using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "categoria",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "perfil",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    categoria_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalSchema: "public",
                        principalTable: "categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "perfil_permissao",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    perfil_id = table.Column<long>(type: "bigint", nullable: false),
                    permissao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_permissao", x => x.id);
                    table.ForeignKey(
                        name: "FK_perfil_permissao_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalSchema: "public",
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    data_edicao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    nome = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    perfil_id = table.Column<long>(type: "bigint", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    refresh_token = table.Column<string>(type: "text", nullable: false),
                    refresh_token_expiry_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_perfil_perfil_id",
                        column: x => x.perfil_id,
                        principalSchema: "public",
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_perfil_permissao_perfil_id",
                schema: "public",
                table: "perfil_permissao",
                column: "perfil_id");

            migrationBuilder.CreateIndex(
                name: "IX_produto_categoria_id",
                schema: "public",
                table: "produto",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfil_id",
                schema: "public",
                table: "usuario",
                column: "perfil_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfil_permissao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "produto",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usuario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "categoria",
                schema: "public");

            migrationBuilder.DropTable(
                name: "perfil",
                schema: "public");
        }
    }
}
