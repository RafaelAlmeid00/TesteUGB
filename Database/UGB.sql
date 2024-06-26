USE [master]
GO
/****** Object:  Database [UGB]    Script Date: 16/04/2024 15:35:13 ******/
CREATE DATABASE [UGB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UGB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\UGB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UGB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\UGB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [UGB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UGB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UGB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UGB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UGB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UGB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UGB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UGB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UGB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UGB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UGB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UGB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UGB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UGB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UGB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UGB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UGB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UGB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UGB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UGB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UGB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UGB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UGB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UGB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UGB] SET RECOVERY FULL 
GO
ALTER DATABASE [UGB] SET  MULTI_USER 
GO
ALTER DATABASE [UGB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UGB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UGB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UGB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UGB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UGB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'UGB', N'ON'
GO
ALTER DATABASE [UGB] SET QUERY_STORE = ON
GO
ALTER DATABASE [UGB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [UGB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrada_Estoque]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrada_Estoque](
	[entrada_id] [int] IDENTITY(1,1) NOT NULL,
	[entrada_nf] [varchar](45) NOT NULL,
	[entrada_deposito] [varchar](45) NOT NULL,
	[entrada_quantidade] [int] NOT NULL,
	[entrada_data] [date] NOT NULL,
	[Usuario_user_mat] [varchar](14) NOT NULL,
	[Produto_prod_ean] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[entrada_id] ASC,
	[Usuario_user_mat] ASC,
	[Produto_prod_ean] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estoque]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estoque](
	[estoque_id] [int] IDENTITY(1,1) NOT NULL,
	[estoque_quantidade] [int] NOT NULL,
	[Produto_prod_ean] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[estoque_id] ASC,
	[Produto_prod_ean] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[fornecedor_CNPJ] [varchar](14) NOT NULL,
	[fornecedor_email] [varchar](45) NOT NULL,
	[fornecedor_insestadual] [varchar](14) NOT NULL,
	[fornecedor_insmunicipal] [varchar](14) NOT NULL,
	[fornecedor_cep] [varchar](8) NOT NULL,
	[fornecedor_bairro] [varchar](45) NULL,
	[fornecedor_cidade] [varchar](45) NOT NULL,
	[fornecedor_uf] [varchar](2) NOT NULL,
	[fornecedor_rua] [varchar](45) NOT NULL,
	[fornecedor_numero] [int] NOT NULL,
	[Usuario_user_mat] [varchar](14) NOT NULL,
	[fornecedor_nome] [varchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[fornecedor_CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordem_Compra]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordem_Compra](
	[ordem_id] [int] IDENTITY(1,1) NOT NULL,
	[ordem_quantidade] [int] NOT NULL,
	[ordem_precototal] [decimal](18, 0) NOT NULL,
	[Pedido_Interno_pedido_id] [int] NOT NULL,
	[Pedido_Interno_Usuario_user_mat] [varchar](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ordem_id] ASC,
	[Pedido_Interno_pedido_id] ASC,
	[Pedido_Interno_Usuario_user_mat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido_Interno]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido_Interno](
	[pedido_id] [int] IDENTITY(1,1) NOT NULL,
	[pedido_quantidade] [int] NOT NULL,
	[pedido_data] [date] NOT NULL,
	[Usuario_user_mat] [varchar](14) NOT NULL,
	[Produto_prod_ean] [varchar](60) NULL,
	[Servico_serv_id] [int] NULL,
	[pedido_observacao] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[pedido_id] ASC,
	[Usuario_user_mat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[prod_ean] [varchar](60) NOT NULL,
	[prod_nome] [varchar](45) NULL,
	[prod_preco] [decimal](18, 0) NOT NULL,
	[prod_fabricante] [varchar](45) NULL,
	[prod_estoqueminimo] [varchar](45) NULL,
	[Usuario_user_mat] [varchar](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[prod_ean] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saida_Estoque]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saida_Estoque](
	[saida_id] [int] IDENTITY(1,1) NOT NULL,
	[saida_quantidade] [int] NOT NULL,
	[entrada_data] [date] NOT NULL,
	[Usuario_user_mat] [varchar](14) NOT NULL,
	[Produto_prod_ean] [varchar](60) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[saida_id] ASC,
	[Usuario_user_mat] ASC,
	[Produto_prod_ean] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servico]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servico](
	[serv_id] [int] IDENTITY(1,1) NOT NULL,
	[serv_nome] [varchar](45) NOT NULL,
	[serv_descricao] [text] NOT NULL,
	[serv_prazo] [varchar](45) NOT NULL,
	[Usuario_user_mat] [varchar](14) NOT NULL,
	[Fornecedor_fornecedor_CNPJ] [varchar](14) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[serv_id] ASC,
	[Fornecedor_fornecedor_CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 16/04/2024 15:35:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[user_mat] [varchar](14) NOT NULL,
	[user_nome] [varchar](45) NOT NULL,
	[user_email] [varchar](45) NOT NULL,
	[user_senha] [varchar](65) NOT NULL,
	[user_departamento] [varchar](45) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_mat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[user_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Produto] ADD  CONSTRAINT [DF_Prod_Preco]  DEFAULT ((0.00)) FOR [prod_preco]
GO
ALTER TABLE [dbo].[Entrada_Estoque]  WITH CHECK ADD  CONSTRAINT [fk_Entrada_Estoque_Produto1] FOREIGN KEY([Produto_prod_ean])
REFERENCES [dbo].[Produto] ([prod_ean])
GO
ALTER TABLE [dbo].[Entrada_Estoque] CHECK CONSTRAINT [fk_Entrada_Estoque_Produto1]
GO
ALTER TABLE [dbo].[Entrada_Estoque]  WITH CHECK ADD  CONSTRAINT [fk_Entrada_Estoque_Usuario1] FOREIGN KEY([Usuario_user_mat])
REFERENCES [dbo].[Usuario] ([user_mat])
GO
ALTER TABLE [dbo].[Entrada_Estoque] CHECK CONSTRAINT [fk_Entrada_Estoque_Usuario1]
GO
ALTER TABLE [dbo].[Estoque]  WITH CHECK ADD  CONSTRAINT [fk_Estoque_Produto1] FOREIGN KEY([Produto_prod_ean])
REFERENCES [dbo].[Produto] ([prod_ean])
GO
ALTER TABLE [dbo].[Estoque] CHECK CONSTRAINT [fk_Estoque_Produto1]
GO
ALTER TABLE [dbo].[Fornecedor]  WITH CHECK ADD  CONSTRAINT [fk_Fornecedor_Usuario1] FOREIGN KEY([Usuario_user_mat])
REFERENCES [dbo].[Usuario] ([user_mat])
GO
ALTER TABLE [dbo].[Fornecedor] CHECK CONSTRAINT [fk_Fornecedor_Usuario1]
GO
ALTER TABLE [dbo].[Ordem_Compra]  WITH CHECK ADD  CONSTRAINT [fk_Ordem_Compra_Pedido_Interno1] FOREIGN KEY([Pedido_Interno_pedido_id], [Pedido_Interno_Usuario_user_mat])
REFERENCES [dbo].[Pedido_Interno] ([pedido_id], [Usuario_user_mat])
GO
ALTER TABLE [dbo].[Ordem_Compra] CHECK CONSTRAINT [fk_Ordem_Compra_Pedido_Interno1]
GO
ALTER TABLE [dbo].[Pedido_Interno]  WITH CHECK ADD  CONSTRAINT [fk_Pedido_Interno_Usuario1] FOREIGN KEY([Usuario_user_mat])
REFERENCES [dbo].[Usuario] ([user_mat])
GO
ALTER TABLE [dbo].[Pedido_Interno] CHECK CONSTRAINT [fk_Pedido_Interno_Usuario1]
GO
ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [fk_Produto_Usuario] FOREIGN KEY([Usuario_user_mat])
REFERENCES [dbo].[Usuario] ([user_mat])
GO
ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [fk_Produto_Usuario]
GO
ALTER TABLE [dbo].[Saida_Estoque]  WITH CHECK ADD  CONSTRAINT [fk_Saida_Estoque_Produto1] FOREIGN KEY([Produto_prod_ean])
REFERENCES [dbo].[Produto] ([prod_ean])
GO
ALTER TABLE [dbo].[Saida_Estoque] CHECK CONSTRAINT [fk_Saida_Estoque_Produto1]
GO
ALTER TABLE [dbo].[Saida_Estoque]  WITH CHECK ADD  CONSTRAINT [fk_Saida_Estoque_Usuario1] FOREIGN KEY([Usuario_user_mat])
REFERENCES [dbo].[Usuario] ([user_mat])
GO
ALTER TABLE [dbo].[Saida_Estoque] CHECK CONSTRAINT [fk_Saida_Estoque_Usuario1]
GO
ALTER TABLE [dbo].[Servico]  WITH CHECK ADD  CONSTRAINT [fk_Servico_Fornecedor1] FOREIGN KEY([Fornecedor_fornecedor_CNPJ])
REFERENCES [dbo].[Fornecedor] ([fornecedor_CNPJ])
GO
ALTER TABLE [dbo].[Servico] CHECK CONSTRAINT [fk_Servico_Fornecedor1]
GO
ALTER TABLE [dbo].[Servico]  WITH CHECK ADD  CONSTRAINT [fk_Servico_Usuario1] FOREIGN KEY([Usuario_user_mat])
REFERENCES [dbo].[Usuario] ([user_mat])
GO
ALTER TABLE [dbo].[Servico] CHECK CONSTRAINT [fk_Servico_Usuario1]
GO
USE [master]
GO
ALTER DATABASE [UGB] SET  READ_WRITE 
GO
