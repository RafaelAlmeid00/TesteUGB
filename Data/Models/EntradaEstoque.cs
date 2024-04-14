using System;
using System.Collections.Generic;

namespace UGB.Data
{

public partial class EntradaEstoque
{
    public int EntradaId { get; set; }

    public string EntradaNf { get; set; } = null!;

    public string EntradaDeposito { get; set; } = null!;

    public int EntradaQuantidade { get; set; }

    public DateOnly EntradaData { get; set; }

    public int UsuarioUserMat { get; set; }

    public int ProdutoProdEan { get; set; }

    public virtual Produto ProdutoProdEanNavigation { get; set; } = null!;

    public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
}
}