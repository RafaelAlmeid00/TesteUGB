namespace UGB.Data;
public interface IEstoque
{
    int EstoqueId { get; set; }
    int? Quantidade { get; set; }
    string ProdutoProdEan { get; set; }
    string? EstoqueMinimo { get; set; }
    string? StatusEstoque { get; set; }
}