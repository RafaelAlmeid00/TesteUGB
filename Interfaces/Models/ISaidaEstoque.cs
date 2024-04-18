namespace UGB.Data;
public interface ISaidaEstoque
{
    int SaidaId { get; set; }
    int SaidaQuantidade { get; set; }
    DateOnly? EntradaData { get; set; }
    string? UsuarioUserMat { get; set; }
    string? ProdutoProdEan { get; set; }
}