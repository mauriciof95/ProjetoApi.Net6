using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class alter_table_pedido_item_rename_valor_unitario_pago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor_pago",
                schema: "public",
                table: "pedido_item",
                newName: "valor_unitario_pago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "valor_unitario_pago",
                schema: "public",
                table: "pedido_item",
                newName: "valor_pago");
        }
    }
}
