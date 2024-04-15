namespace UGB.Interface;
public interface IPedidoInterno
{
    int PedidoId { get; set; }

    int PedidoQuantidade { get; set; }
    string? UsuarioUserMat { get; set; }

    string? ProdutoProdEan { get; set; }
    int? ServicoServId { get; set; }
    string? ServicoObservação { get; set; }
}