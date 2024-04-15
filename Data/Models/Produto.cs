using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UGB.Interface;

namespace UGB.Data
{
    public partial class Produto : IProduto
    {
        [Key]
        [StringLength(13, ErrorMessage = "Código EAN só pode ter 13 digitos.")]
        [Required(ErrorMessage = "Por favor, insira o código EAN.")]

        public required string ProdEan { get; set; }
        [Required(ErrorMessage = "Por favor, insira o nome.")]

        public string? ProdNome { get; set; }
        [Required(ErrorMessage = "Por favor, insira o preço.")]

        public string? ProdPreco { get; set; }
        [Required(ErrorMessage = "Por favor, insira o fabricante.")]

        public string? ProdFabricante { get; set; }

        [Required(ErrorMessage = "Por favor, insira o estoque minimo do produto.")]
        public string? ProdEstoqueminimo { get; set; }
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Por favor, insira o nome.")]
        public string? UsuarioUserMat { get; set; }

    }
}