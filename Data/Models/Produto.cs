using System;
using System.Collections.Generic;

namespace UGB.Data
{
public partial class Produto
{
    public int ProdEan { get; set; }

    public string? ProdNome { get; set; }

    public string? ProdPreco { get; set; }

    public string? ProdFabricante { get; set; }

    public string? ProdEstoqueminimo { get; set; }

    public int UsuarioUserMat { get; set; }

    public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
}
}