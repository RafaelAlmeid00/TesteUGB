using System;
using System.Collections.Generic;

namespace UGB.Data
{
public partial class OrdemCompra
{
    public int OrdemId { get; set; }

    public int OrdemQuantidade { get; set; }

    public decimal OrdemPrecototal { get; set; }

    public int PedidoInternoPedidoId { get; set; }

    public int PedidoInternoUsuarioUserMat { get; set; }

    public virtual PedidoInterno PedidoInterno { get; set; } = null!;
}
}