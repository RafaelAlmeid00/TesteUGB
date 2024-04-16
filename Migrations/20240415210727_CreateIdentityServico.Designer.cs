﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UGB.Data;

#nullable disable

namespace UGB.Migrations
{
    [DbContext(typeof(UGBContext))]
    [Migration("20240415210727_CreateIdentityServico")]
    partial class CreateIdentityServico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UGB.Data.EntradaEstoque", b =>
                {
                    b.Property<int>("EntradaId")
                        .HasColumnType("int")
                        .HasColumnName("entrada_id");

                    b.Property<int>("UsuarioUserMat")
                        .HasColumnType("int")
                        .HasColumnName("Usuario_user_mat");

                    b.Property<int>("ProdutoProdEan")
                        .HasColumnType("int")
                        .HasColumnName("Produto_prod_ean");

                    b.Property<DateOnly>("EntradaData")
                        .HasColumnType("date")
                        .HasColumnName("entrada_data");

                    b.Property<string>("EntradaDeposito")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("entrada_deposito");

                    b.Property<string>("EntradaNf")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("entrada_nf");

                    b.Property<int>("EntradaQuantidade")
                        .HasColumnType("int")
                        .HasColumnName("entrada_quantidade");

                    b.Property<string>("ProdutoProdEanNavigationProdEan")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("UsuarioUserMatNavigationUserMat")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EntradaId", "UsuarioUserMat", "ProdutoProdEan")
                        .HasName("PK__Entrada___CC134D53AB58E469");

                    b.HasIndex("ProdutoProdEanNavigationProdEan");

                    b.HasIndex("UsuarioUserMatNavigationUserMat");

                    b.ToTable("Entrada_Estoque", (string)null);
                });

            modelBuilder.Entity("UGB.Data.Estoque", b =>
                {
                    b.Property<int>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("estoque_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstoqueId"));

                    b.Property<string>("ProdutoProdEan")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("Produto_prod_ean");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("estoque_quantidade");

                    b.HasKey("EstoqueId");

                    b.HasIndex("ProdutoProdEan");

                    b.ToTable("Estoque", (string)null);
                });

            modelBuilder.Entity("UGB.Data.Fornecedor", b =>
                {
                    b.Property<string>("FornecedorCnpj")
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("fornecedor_CNPJ");

                    b.Property<string>("FornecedorBairro")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("fornecedor_bairro")
                        .HasComputedColumnSql("('')", true);

                    b.Property<string>("FornecedorCep")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("fornecedor_cep");

                    b.Property<string>("FornecedorCidade")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fornecedor_cidade");

                    b.Property<string>("FornecedorEmail")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fornecedor_email");

                    b.Property<string>("FornecedorInsestadual")
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("fornecedor_insestadual");

                    b.Property<string>("FornecedorInsmunicipal")
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("fornecedor_insmunicipal");

                    b.Property<string>("FornecedorNome")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fornecedor_nome");

                    b.Property<int?>("FornecedorNumero")
                        .HasColumnType("int")
                        .HasColumnName("fornecedor_numero");

                    b.Property<string>("FornecedorRua")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fornecedor_rua");

                    b.Property<string>("FornecedorUf")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("fornecedor_uf");

                    b.Property<string>("UsuarioUserMat")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Usuario_user_mat");

                    b.HasKey("FornecedorCnpj")
                        .HasName("PK__Forneced__2BF638797C48E672");

                    b.ToTable("Fornecedor", (string)null);
                });

            modelBuilder.Entity("UGB.Data.OrdemCompra", b =>
                {
                    b.Property<int>("OrdemId")
                        .HasColumnType("int")
                        .HasColumnName("ordem_id");

                    b.Property<int>("PedidoInternoPedidoId")
                        .HasColumnType("int")
                        .HasColumnName("Pedido_Interno_pedido_id");

                    b.Property<int>("PedidoInternoUsuarioUserMat")
                        .HasColumnType("int")
                        .HasColumnName("Pedido_Interno_Usuario_user_mat");

                    b.Property<decimal>("OrdemPrecototal")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("ordem_precototal");

                    b.Property<int>("OrdemQuantidade")
                        .HasColumnType("int")
                        .HasColumnName("ordem_quantidade");

                    b.Property<int>("PedidoInternoPedidoId1")
                        .HasColumnType("int");

                    b.Property<string>("PedidoInternoUsuarioUserMat1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrdemId", "PedidoInternoPedidoId", "PedidoInternoUsuarioUserMat")
                        .HasName("PK__Ordem_Co__0E2B5B07C8D4943B");

                    b.HasIndex("PedidoInternoPedidoId1", "PedidoInternoUsuarioUserMat1");

                    b.ToTable("Ordem_Compra", (string)null);
                });

            modelBuilder.Entity("UGB.Data.PedidoInterno", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int")
                        .HasColumnName("pedido_id");

                    b.Property<string>("UsuarioUserMat")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Usuario_user_mat");

                    b.Property<DateOnly>("PedidoData")
                        .HasColumnType("date")
                        .HasColumnName("pedido_data");

                    b.Property<int>("PedidoQuantidade")
                        .HasColumnType("int")
                        .HasColumnName("pedido_quantidade");

                    b.Property<string>("ProdutoProdEan")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Produto_prod_ean");

                    b.Property<string>("ServicoObservação")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pedido_observacao");

                    b.Property<int?>("ServicoServId")
                        .HasColumnType("int")
                        .HasColumnName("Servico_serv_id");

                    b.HasKey("PedidoId", "UsuarioUserMat")
                        .HasName("PK__Pedido_I__4BAA591F13DFFFA6");

                    b.HasIndex("UsuarioUserMat");

                    b.ToTable("Pedido_Interno", (string)null);
                });

            modelBuilder.Entity("UGB.Data.Produto", b =>
                {
                    b.Property<string>("ProdEan")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("prod_ean");

                    b.Property<string>("ProdEstoqueminimo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("prod_estoqueminimo");

                    b.Property<string>("ProdFabricante")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("prod_fabricante");

                    b.Property<string>("ProdNome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("prod_nome");

                    b.Property<string>("ProdPreco")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("prod_preco");

                    b.Property<string>("UsuarioUserMat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Usuario_user_mat");

                    b.HasKey("ProdEan")
                        .HasName("PK__Produto__C12992A8D080D5D4");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("UGB.Data.SaidaEstoque", b =>
                {
                    b.Property<int>("SaidaId")
                        .HasColumnType("int")
                        .HasColumnName("saida_id");

                    b.Property<int>("UsuarioUserMat")
                        .HasColumnType("int")
                        .HasColumnName("Usuario_user_mat");

                    b.Property<int>("ProdutoProdEan")
                        .HasColumnType("int")
                        .HasColumnName("Produto_prod_ean");

                    b.Property<DateOnly>("EntradaData")
                        .HasColumnType("date")
                        .HasColumnName("entrada_data");

                    b.Property<string>("ProdutoProdEanNavigationProdEan")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("SaidaQuantidade")
                        .HasColumnType("int")
                        .HasColumnName("saida_quantidade");

                    b.Property<string>("UsuarioUserMatNavigationUserMat")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SaidaId", "UsuarioUserMat", "ProdutoProdEan")
                        .HasName("PK__Saida_Es__4EE572A5EB1405E0");

                    b.HasIndex("ProdutoProdEanNavigationProdEan");

                    b.HasIndex("UsuarioUserMatNavigationUserMat");

                    b.ToTable("Saida_Estoque", (string)null);
                });

            modelBuilder.Entity("UGB.Data.Serviço", b =>
                {
                    b.Property<int>("ServId")
                        .HasColumnType("int")
                        .HasColumnName("serv_id");

                    b.Property<string>("FornecedorFornecedorCnpj")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Fornecedor_fornecedor_CNPJ");

                    b.Property<string>("ServDescricao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("serv_descricao");

                    b.Property<string>("ServNome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("serv_nome");

                    b.Property<string>("ServPrazo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("serv_prazo");

                    b.Property<string>("UsuarioUserMat")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Usuario_user_mat");

                    b.HasKey("ServId", "FornecedorFornecedorCnpj")
                        .HasName("PK__Servico__6A366E20137D165B");

                    b.ToTable("Servico", (string)null);
                });

            modelBuilder.Entity("UGB.Data.Usuario", b =>
                {
                    b.Property<string>("UserMat")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("user_mat");

                    b.Property<string>("UserDepartamento")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("user_departamento");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserNome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("user_nome");

                    b.Property<string>("UserSenha")
                        .IsRequired()
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("user_senha");

                    b.HasKey("UserMat")
                        .HasName("PK__Usuario__E148B05A9DCA454D");

                    b.HasIndex(new[] { "UserEmail" }, "user_email_UNIQUE")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("UGB.Data.EntradaEstoque", b =>
                {
                    b.HasOne("UGB.Data.Produto", "ProdutoProdEanNavigation")
                        .WithMany()
                        .HasForeignKey("ProdutoProdEanNavigationProdEan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UGB.Data.Usuario", "UsuarioUserMatNavigation")
                        .WithMany()
                        .HasForeignKey("UsuarioUserMatNavigationUserMat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoProdEanNavigation");

                    b.Navigation("UsuarioUserMatNavigation");
                });

            modelBuilder.Entity("UGB.Data.Estoque", b =>
                {
                    b.HasOne("UGB.Data.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoProdEan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_Estoque_Produto1");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UGB.Data.OrdemCompra", b =>
                {
                    b.HasOne("UGB.Data.PedidoInterno", "PedidoInterno")
                        .WithMany()
                        .HasForeignKey("PedidoInternoPedidoId1", "PedidoInternoUsuarioUserMat1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PedidoInterno");
                });

            modelBuilder.Entity("UGB.Data.PedidoInterno", b =>
                {
                    b.HasOne("UGB.Data.Usuario", "UsuarioUserMatNavigation")
                        .WithMany()
                        .HasForeignKey("UsuarioUserMat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioUserMatNavigation");
                });

            modelBuilder.Entity("UGB.Data.SaidaEstoque", b =>
                {
                    b.HasOne("UGB.Data.Produto", "ProdutoProdEanNavigation")
                        .WithMany()
                        .HasForeignKey("ProdutoProdEanNavigationProdEan");

                    b.HasOne("UGB.Data.Usuario", "UsuarioUserMatNavigation")
                        .WithMany()
                        .HasForeignKey("UsuarioUserMatNavigationUserMat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoProdEanNavigation");

                    b.Navigation("UsuarioUserMatNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
