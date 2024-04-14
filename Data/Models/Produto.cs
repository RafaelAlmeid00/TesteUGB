using UGB.Interface;

namespace UGB.Data
{
public partial class Produto : IProduto
{
    public required string ProdEan { get; set; }

    public string? ProdNome { get; set; }

    public string? ProdPreco { get; set; }

    public string? ProdFabricante { get; set; }

    public string? ProdEstoqueminimo { get; set; }

    public string? UsuarioUserMat { get; set; }

    }
}