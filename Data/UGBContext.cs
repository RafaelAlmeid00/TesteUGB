using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UGB.Data;

public partial class UGBContext : DbContext
{
    public UGBContext()
    {
    }

    public UGBContext(DbContextOptions<UGBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EntradaEstoque> EntradaEstoques { get; set; }

    public virtual DbSet<Fornecedor> Fornecedors { get; set; }

    public virtual DbSet<OrdemCompra> OrdemCompras { get; set; }

    public virtual DbSet<PedidoInterno> PedidoInternos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<SaidaEstoque> SaidaEstoques { get; set; }

    public virtual DbSet<Serviço> Serviços { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Estoque> Estoques { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=localhost;Database=UGB;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EntradaEstoque>(entity =>
        {
            entity.HasKey(e => new { e.EntradaId, e.UsuarioUserMat, e.ProdutoProdEan }).HasName("PK__Entrada___CC134D53AB58E469");

            entity.ToTable("Entrada_Estoque");

            entity.Property(e => e.EntradaId).HasColumnName("entrada_id");
            entity.Property(e => e.UsuarioUserMat).HasColumnName("Usuario_user_mat");
            entity.Property(e => e.ProdutoProdEan).HasColumnName("Produto_prod_ean");
            entity.Property(e => e.EntradaData).HasColumnName("entrada_data");
            entity.Property(e => e.EntradaDeposito)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("entrada_deposito");
            entity.Property(e => e.EntradaNf)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("entrada_nf");
            entity.Property(e => e.EntradaQuantidade).HasColumnName("entrada_quantidade");
        });

        modelBuilder.Entity<Fornecedor>(entity =>
        {
            entity.HasKey(e => e.FornecedorCnpj).HasName("PK__Forneced__2BF638797C48E672");

            entity.ToTable("Fornecedor");

            entity.Property(e => e.FornecedorCnpj)
                .ValueGeneratedNever()
                .HasColumnName("fornecedor_CNPJ");
            entity.Property(e => e.FornecedorBairro)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasComputedColumnSql("('')", true)
                .HasColumnName("fornecedor_bairro");
            entity.Property(e => e.FornecedorCep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("fornecedor_cep");
            entity.Property(e => e.FornecedorCidade)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("fornecedor_cidade");
            entity.Property(e => e.FornecedorEmail)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("fornecedor_email");
            entity.Property(e => e.FornecedorInsestadual)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("fornecedor_insestadual");
            entity.Property(e => e.FornecedorInsmunicipal)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("fornecedor_insmunicipal");
            entity.Property(e => e.FornecedorNumero).HasColumnName("fornecedor_numero");
            entity.Property(e => e.FornecedorRua)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("fornecedor_rua");
            entity.Property(e => e.FornecedorUf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("fornecedor_uf");
            entity.Property(e => e.UsuarioUserMat).HasColumnName("Usuario_user_mat");
        });

        modelBuilder.Entity<OrdemCompra>(entity =>
        {
            entity.HasKey(e => new { e.OrdemId, e.PedidoInternoPedidoId, e.PedidoInternoUsuarioUserMat }).HasName("PK__Ordem_Co__0E2B5B07C8D4943B");

            entity.ToTable("Ordem_Compra");

            entity.Property(e => e.OrdemId).HasColumnName("ordem_id");
            entity.Property(e => e.PedidoInternoPedidoId).HasColumnName("Pedido_Interno_pedido_id");
            entity.Property(e => e.PedidoInternoUsuarioUserMat).HasColumnName("Pedido_Interno_Usuario_user_mat");
            entity.Property(e => e.OrdemPrecototal)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("ordem_precototal");
            entity.Property(e => e.OrdemQuantidade).HasColumnName("ordem_quantidade");
        });

        modelBuilder.Entity<PedidoInterno>(entity =>
        {
            entity.HasKey(e => new { e.PedidoId, e.UsuarioUserMat }).HasName("PK__Pedido_I__4BAA591F13DFFFA6");

            entity.ToTable("Pedido_Interno");

            entity.Property(e => e.PedidoId).HasColumnName("pedido_id");
            entity.Property(e => e.UsuarioUserMat).HasColumnName("Usuario_user_mat");
            entity.Property(e => e.PedidoData).HasColumnName("pedido_data");
            entity.Property(e => e.PedidoQuantidade).HasColumnName("pedido_quantidade");
            entity.Property(e => e.ProdutoProdEan).HasColumnName("Produto_prod_ean");
            entity.Property(e => e.ServicoServId).HasColumnName("Servico_serv_id");
            entity.Property(e => e.ServicoObservação).HasColumnName("pedido_observacao");

        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.ProdEan).HasName("PK__Produto__C12992A8D080D5D4");

            entity.ToTable("Produto");

            entity.Property(e => e.ProdEan)
                .ValueGeneratedNever()
                .HasColumnName("prod_ean");
            entity.Property(e => e.ProdEstoqueminimo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("prod_estoqueminimo");
            entity.Property(e => e.ProdFabricante)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("prod_fabricante");
            entity.Property(e => e.ProdNome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("prod_nome");
            entity.Property(e => e.ProdPreco)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("prod_preco");
            entity.Property(e => e.UsuarioUserMat).HasColumnName("Usuario_user_mat");
        });

        modelBuilder.Entity<SaidaEstoque>(entity =>
        {
            entity.HasKey(e => new { e.SaidaId, e.UsuarioUserMat, e.ProdutoProdEan }).HasName("PK__Saida_Es__4EE572A5EB1405E0");

            entity.ToTable("Saida_Estoque");

            entity.Property(e => e.SaidaId).HasColumnName("saida_id");
            entity.Property(e => e.UsuarioUserMat).HasColumnName("Usuario_user_mat");
            entity.Property(e => e.ProdutoProdEan).HasColumnName("Produto_prod_ean");
            entity.Property(e => e.EntradaData).HasColumnName("entrada_data");
            entity.Property(e => e.SaidaQuantidade).HasColumnName("saida_quantidade");
        });

        modelBuilder.Entity<Serviço>(entity =>
        {
            entity.HasKey(e => new { e.ServId, e.FornecedorFornecedorCnpj }).HasName("PK__Servico__6A366E20137D165B");

            entity.ToTable("Servico");

            entity.Property(e => e.ServId).HasColumnName("serv_id");
            entity.Property(e => e.FornecedorFornecedorCnpj).HasColumnName("Fornecedor_fornecedor_CNPJ");
            entity.Property(e => e.ServDescricao)
                .IsUnicode(false)
                .HasColumnName("serv_descricao");
            entity.Property(e => e.ServNome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("serv_nome");
            entity.Property(e => e.ServPrazo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("serv_prazo");
            entity.Property(e => e.UsuarioUserMat).HasColumnName("Usuario_user_mat");

        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UserMat).HasName("PK__Usuario__E148B05A9DCA454D");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.UserEmail, "user_email_UNIQUE").IsUnique();

            entity.Property(e => e.UserMat)
                .ValueGeneratedNever()
                .HasColumnName("user_mat");
            entity.Property(e => e.UserDepartamento)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_departamento");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_email");
            entity.Property(e => e.UserNome)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_nome");
            entity.Property(e => e.UserSenha)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("user_senha");
        });

        modelBuilder.Entity<Estoque>(entity =>
{
    entity.ToTable("Estoque");

    entity.Property(e => e.EstoqueId).HasColumnName("estoque_id");
    entity.Property(e => e.Quantidade).HasColumnName("estoque_quantidade");
    entity.Property(e => e.ProdutoProdEan).HasColumnName("Produto_prod_ean");

    entity.HasKey(e => e.EstoqueId);
    entity.HasOne(e => e.Produto)
        .WithMany()
        .HasForeignKey(e => e.ProdutoProdEan)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName("fk_Estoque_Produto1");
});


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
