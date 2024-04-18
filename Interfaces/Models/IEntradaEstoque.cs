namespace UGB.Data;
public interface IEntradaEstoque
{
    int EntradaId { get; set; }

    string EntradaNf { get; set; }

    string EntradaDeposito { get; set; }

    int? EntradaQuantidade { get; set; }

    DateOnly? EntradaData { get; set; }

    string UsuarioUserMat { get; set; }

    string ProdutoProdEan { get; set; }

}