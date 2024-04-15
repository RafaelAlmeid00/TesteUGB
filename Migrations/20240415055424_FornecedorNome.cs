using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UGB.Migrations
{
    /// <inheritdoc />
    public partial class FornecedorNome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_mat",
                table: "Usuario",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioUserMatNavigationUserMat",
                table: "Saida_Estoque",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)");

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

            migrationBuilder.AlterColumn<string>(
                name: "pedido_observacao",
                table: "Pedido_Interno",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Usuario_user_mat",
                table: "Pedido_Interno",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "PedidoInternoUsuarioUserMat1",
                table: "Ordem_Compra",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_uf",
                table: "Fornecedor",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_rua",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_insmunicipal",
                table: "Fornecedor",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false,
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_insestadual",
                table: "Fornecedor",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false,
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_email",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_cidade",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_cep",
                table: "Fornecedor",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldUnicode: false,
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_CNPJ",
                table: "Fornecedor",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "fornecedor_nome",
                table: "Fornecedor",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioUserMatNavigationUserMat",
                table: "Entrada_Estoque",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoProdEanNavigationProdEan",
                table: "Entrada_Estoque",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_bairro",
                table: "Fornecedor",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                computedColumnSql: "('')",
                stored: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldComputedColumnSql: "('')",
                oldStored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_mat",
                table: "Usuario",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioUserMatNavigationUserMat",
                table: "Saida_Estoque",
                type: "nvarchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AlterColumn<string>(
                name: "pedido_observacao",
                table: "Pedido_Interno",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Usuario_user_mat",
                table: "Pedido_Interno",
                type: "nvarchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PedidoInternoUsuarioUserMat1",
                table: "Ordem_Compra",
                type: "nvarchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_uf",
                table: "Fornecedor",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_rua",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_insmunicipal",
                table: "Fornecedor",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false,
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_insestadual",
                table: "Fornecedor",
                type: "varchar(14)",
                unicode: false,
                maxLength: 14,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldUnicode: false,
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_email",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_cidade",
                table: "Fornecedor",
                type: "varchar(45)",
                unicode: false,
                maxLength: 45,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(45)",
                oldUnicode: false,
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_cep",
                table: "Fornecedor",
                type: "varchar(8)",
                unicode: false,
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldUnicode: false,
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fornecedor_CNPJ",
                table: "Fornecedor",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioUserMatNavigationUserMat",
                table: "Entrada_Estoque",
                type: "nvarchar(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProdutoProdEanNavigationProdEan",
                table: "Entrada_Estoque",
                type: "nvarchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "fornecedor_bairro",
                table: "Fornecedor",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: false,
                computedColumnSql: "('')",
                stored: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true,
                oldComputedColumnSql: "('')",
                oldStored: true);
        }
    }
}
