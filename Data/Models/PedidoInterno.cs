using System;
using System.Collections.Generic;

namespace UGB.Data
{
public partial class PedidoInterno
{
    public int PedidoId { get; set; }

    public int PedidoQuantidade { get; set; }

    public DateOnly PedidoData { get; set; }

    public int UsuarioUserMat { get; set; }

    public int? ProdutoProdEan { get; set; }

    public int? ServiçoServId { get; set; }

    public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
}
}