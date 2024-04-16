namespace UGB.Data;
public interface IOrdemCompra
{
    int OrdemId { get; set; }
    int OrdemQuantidade { get; set; }
    decimal OrdemPrecototal { get; set; }
    int? PedidoInternoPedidoId { get; set; }
    string? PedidoInternoUsuarioUserMat { get; set; }
}