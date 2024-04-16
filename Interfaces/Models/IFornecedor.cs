namespace UGB.Data;
public interface IFornecedor
{
    string? FornecedorCnpj { get; set; }
    string? FornecedorNome { get; set; }
    string? FornecedorEmail { get; set; }

    string? FornecedorInsestadual { get; set; }
    string? FornecedorInsmunicipal { get; set; }
    string? FornecedorCep { get; set; }
    string? FornecedorBairro { get; set; }
    string? FornecedorCidade { get; set; }
    string? FornecedorUf { get; set; }
    string? FornecedorRua { get; set; }
    int? FornecedorNumero { get; set; }
    string? UsuarioUserMat { get; set; }

}