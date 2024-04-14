using System;
using System.Collections.Generic;

namespace UGB.Data
{
public partial class Fornecedor
{
    public int FornecedorCnpj { get; set; }

    public string FornecedorEmail { get; set; } = null!;

    public string FornecedorInsestadual { get; set; } = null!;

    public string FornecedorInsmunicipal { get; set; } = null!;

    public string FornecedorCep { get; set; } = null!;

    public string FornecedorBairro { get; set; } = null!;

    public string FornecedorCidade { get; set; } = null!;

    public string FornecedorUf { get; set; } = null!;

    public string FornecedorRua { get; set; } = null!;

    public int FornecedorNumero { get; set; }

    public int UsuarioUserMat { get; set; }

    public virtual ICollection<Serviço> Serviços { get; set; } = new List<Serviço>();

    public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
}
}