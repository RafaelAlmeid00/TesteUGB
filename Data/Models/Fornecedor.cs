using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data
{
    public partial class Fornecedor
    {
        [Key]
        [StringLength(14, ErrorMessage = "CNPJ só pode ter 14 digitos.")]
        public string? FornecedorCnpj { get; set; }
        public string? FornecedorNome { get; set; }
        [EmailAddress]
        public string? FornecedorEmail { get; set; }
        [MinLength(9, ErrorMessage = "A inscrição estadual só pode ter 9 digitos.")]

        public string? FornecedorInsestadual { get; set; }
        [StringLength(11, ErrorMessage = "A inscrição municipal só pode ter 11 digitos.")]
        public string? FornecedorInsmunicipal { get; set; }
        [StringLength(8, ErrorMessage = "O CEP só pode ter 8 digitos.")]
        public string? FornecedorCep { get; set; }
        public string? FornecedorBairro { get; set; }
        public string? FornecedorCidade { get; set; }
        public string? FornecedorUf { get; set; }
        public string? FornecedorRua { get; set; }
        public int? FornecedorNumero { get; set; }
        [ForeignKey("Usuario")]
        public string? UsuarioUserMat { get; set; }

    }
}