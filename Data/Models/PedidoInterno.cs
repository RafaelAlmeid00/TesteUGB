
namespace UGB.Data
{
    public class PedidoInterno
    {

        public PedidoInterno()
        {
            PedidoId = 0;
            PedidoQuantidade = 0;
            PedidoData = DateOnly.FromDateTime(DateTime.Today);
            UsuarioUserMat = null;
            ProdutoProdEan = null;
            ServicoServId = null;
            ServicoObservação = null;
        }

        public int PedidoId { get; set; }

        public int PedidoQuantidade { get; set; }

        public DateOnly PedidoData = DateOnly.FromDateTime(DateTime.Today);

        public string? UsuarioUserMat { get; set; }

        public string? ProdutoProdEan { get; set; }
        public int? ServicoServId { get; set; }
        public string? ServicoObservação { get; set; }

        public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
    }
}