using System;
using System.Collections.Generic;

namespace UGB.Data
{
public class SaidaEstoque
{
    public int SaidaId { get; set; }

    public int SaidaQuantidade { get; set; }

    public DateOnly EntradaData { get; set; }

    public int UsuarioUserMat { get; set; }

    public int ProdutoProdEan { get; set; }

    public virtual Produto ProdutoProdEanNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
}
}