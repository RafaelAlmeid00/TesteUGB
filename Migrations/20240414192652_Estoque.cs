using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UGB.Migrations
{
    /// <inheritdoc />
    public partial class Estoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    user_mat = table.Column<int>(type: "int", nullable: false),
                    user_nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    user_email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    user_senha = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    user_departamento = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__E148B05A9DCA454D", x => x.user_mat);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    fornecedor_CNPJ = table.Column<int>(type: "int", nullable: false),
                    fornecedor_email = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    fornecedor_insestadual = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    fornecedor_insmunicipal = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    fornecedor_cep = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    fornecedor_bairro = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, computedColumnSql: "('')", stored: true),
                    fornecedor_cidade = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    fornecedor_uf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    fornecedor_rua = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    fornecedor_numero = table.Column<int>(type: "int", nullable: false),
                    Usuario_user_mat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Forneced__2BF638797C48E672", x => x.fornecedor_CNPJ);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Usuario_Usuario_user_mat",
                        column: x => x.Usuario_user_mat,
                        principalTable: "Usuario",
                        principalColumn: "user_mat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido_Interno",
                columns: table => new
                {
                    pedido_id = table.Column<int>(type: "int", nullable: false),
                    Usuario_user_mat = table.Column<int>(type: "int", nullable: false),
                    pedido_quantidade = table.Column<int>(type: "int", nullable: false),
                    Produto_prod_ean = table.Column<int>(type: "int", nullable: true),
                    Serviço_serv_id = table.Column<int>(type: "int", nullable: true),
                    pedido_observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pedido_data = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pedido_I__4BAA591F13DFFFA6", x => new { x.pedido_id, x.Usuario_user_mat });
                    table.ForeignKey(
                        name: "FK_Pedido_Interno_Usuario_Usuario_user_mat",
                        column: x => x.Usuario_user_mat,
                        principalTable: "Usuario",
                        principalColumn: "user_mat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    prod_ean = table.Column<int>(type: "int", nullable: false),
                    prod_nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    prod_preco = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    prod_fabricante = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    prod_estoqueminimo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
                    Usuario_user_mat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produto__C12992A8D080D5D4", x => x.prod_ean);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_Usuario_user_mat",
                        column: x => x.Usuario_user_mat,
                        principalTable: "Usuario",
                        principalColumn: "user_mat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serviço",
                columns: table => new
                {
                    serv_id = table.Column<int>(type: "int", nullable: false),
                    Fornecedor_fornecedor_CNPJ = table.Column<int>(type: "int", nullable: false),
                    serv_nome = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    serv_descricao = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    serv_prazo = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    Usuario_user_mat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Serviço__6A366E20137D165B", x => new { x.serv_id, x.Fornecedor_fornecedor_CNPJ });
                    table.ForeignKey(
                        name: "FK_Serviço_Fornecedor_Fornecedor_fornecedor_CNPJ",
                        column: x => x.Fornecedor_fornecedor_CNPJ,
                        principalTable: "Fornecedor",
                        principalColumn: "fornecedor_CNPJ");
                    table.ForeignKey(
                        name: "FK_Serviço_Usuario_Usuario_user_mat",
                        column: x => x.Usuario_user_mat,
                        principalTable: "Usuario",
                        principalColumn: "user_mat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordem_Compra",
                columns: table => new
                {
                    ordem_id = table.Column<int>(type: "int", nullable: false),
                    Pedido_Interno_pedido_id = table.Column<int>(type: "int", nullable: false),
                    Pedido_Interno_Usuario_user_mat = table.Column<int>(type: "int", nullable: false),
                    ordem_quantidade = table.Column<int>(type: "int", nullable: false),
                    ordem_precototal = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ordem_Co__0E2B5B07C8D4943B", x => new { x.ordem_id, x.Pedido_Interno_pedido_id, x.Pedido_Interno_Usuario_user_mat });
                    table.ForeignKey(
                        name: "FK_Ordem_Compra_Pedido_Interno_Pedido_Interno_pedido_id_Pedido_Interno_Usuario_user_mat",
                        columns: x => new { x.Pedido_Interno_pedido_id, x.Pedido_Interno_Usuario_user_mat },
                        principalTable: "Pedido_Interno",
                        principalColumns: new[] { "pedido_id", "Usuario_user_mat" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrada_Estoque",
                columns: table => new
                {
                    entrada_id = table.Column<int>(type: "int", nullable: false),
                    Usuario_user_mat = table.Column<int>(type: "int", nullable: false),
                    Produto_prod_ean = table.Column<int>(type: "int", nullable: false),
                    entrada_nf = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    entrada_deposito = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    entrada_quantidade = table.Column<int>(type: "int", nullable: false),
                    entrada_data = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Entrada___CC134D53AB58E469", x => new { x.entrada_id, x.Usuario_user_mat, x.Produto_prod_ean });
                    table.ForeignKey(
                        name: "FK_Entrada_Estoque_Produto_Produto_prod_ean",
                        column: x => x.Produto_prod_ean,
                        principalTable: "Produto",
                        principalColumn: "prod_ean",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Estoque_Usuario_Usuario_user_mat",
                        column: x => x.Usuario_user_mat,
                        principalTable: "Usuario",
                        principalColumn: "user_mat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstoqueQuantiodade = table.Column<int>(type: "int", nullable: false),
                    ProdutoProdEanNavigationProdEan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.EstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoques_Produto_ProdutoProdEanNavigationProdEan",
                        column: x => x.ProdutoProdEanNavigationProdEan,
                        principalTable: "Produto",
                        principalColumn: "prod_ean",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Saida_Estoque",
                columns: table => new
                {
                    saida_id = table.Column<int>(type: "int", nullable: false),
                    Usuario_user_mat = table.Column<int>(type: "int", nullable: false),
                    Produto_prod_ean = table.Column<int>(type: "int", nullable: false),
                    saida_quantidade = table.Column<int>(type: "int", nullable: false),
                    entrada_data = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Saida_Es__4EE572A5EB1405E0", x => new { x.saida_id, x.Usuario_user_mat, x.Produto_prod_ean });
                    table.ForeignKey(
                        name: "FK_Saida_Estoque_Produto_Produto_prod_ean",
                        column: x => x.Produto_prod_ean,
                        principalTable: "Produto",
                        principalColumn: "prod_ean",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Saida_Estoque_Usuario_Usuario_user_mat",
                        column: x => x.Usuario_user_mat,
                        principalTable: "Usuario",
                        principalColumn: "user_mat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Estoque_Produto_prod_ean",
                table: "Entrada_Estoque",
                column: "Produto_prod_ean");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_Estoque_Usuario_user_mat",
                table: "Entrada_Estoque",
                column: "Usuario_user_mat");

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_ProdutoProdEanNavigationProdEan",
                table: "Estoques",
                column: "ProdutoProdEanNavigationProdEan");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Usuario_user_mat",
                table: "Fornecedor",
                column: "Usuario_user_mat");

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_Compra_Pedido_Interno_pedido_id_Pedido_Interno_Usuario_user_mat",
                table: "Ordem_Compra",
                columns: new[] { "Pedido_Interno_pedido_id", "Pedido_Interno_Usuario_user_mat" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Interno_Usuario_user_mat",
                table: "Pedido_Interno",
                column: "Usuario_user_mat");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Usuario_user_mat",
                table: "Produto",
                column: "Usuario_user_mat");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_Estoque_Produto_prod_ean",
                table: "Saida_Estoque",
                column: "Produto_prod_ean");

            migrationBuilder.CreateIndex(
                name: "IX_Saida_Estoque_Usuario_user_mat",
                table: "Saida_Estoque",
                column: "Usuario_user_mat");

            migrationBuilder.CreateIndex(
                name: "IX_Serviço_Fornecedor_fornecedor_CNPJ",
                table: "Serviço",
                column: "Fornecedor_fornecedor_CNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Serviço_Usuario_user_mat",
                table: "Serviço",
                column: "Usuario_user_mat");

            migrationBuilder.CreateIndex(
                name: "user_email_UNIQUE",
                table: "Usuario",
                column: "user_email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada_Estoque");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Ordem_Compra");

            migrationBuilder.DropTable(
                name: "Saida_Estoque");

            migrationBuilder.DropTable(
                name: "Serviço");

            migrationBuilder.DropTable(
                name: "Pedido_Interno");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
