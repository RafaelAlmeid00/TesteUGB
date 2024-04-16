using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UGB.Migrations
{
    /// <inheritdoc />
    public partial class CreateIdentityServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Usuario_user_mat",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Fornecedor_fornecedor_CNPJ",
                table: "Servico",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoProdEanNavigationProdEan",
                table: "Saida_Estoque",
                type: "nvarchar(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Usuario_user_mat",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "prod_ean",
                table: "Produto",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "fornecedor_numero",
                table: "Fornecedor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "fornecedor_nome",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoProdEanNavigationProdEan",
                table: "Entrada_Estoque",
                type: "nvarchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fornecedor_nome",
                table: "Fornecedor");

            migrationBuilder.AlterColumn<int>(
                name: "Usuario_user_mat",
                table: "Servico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fornecedor_fornecedor_CNPJ",
                table: "Servico",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoProdEanNavigationProdEan",
                table: "Saida_Estoque",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Usuario_user_mat",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "prod_ean",
                table: "Produto",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<int>(
                name: "fornecedor_numero",
                table: "Fornecedor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoProdEanNavigationProdEan",
                table: "Entrada_Estoque",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");
        }
    }
}
