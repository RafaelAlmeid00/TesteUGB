using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data
{
    public class SaidaEstoque : ISaidaEstoque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SaidaId { get; set; }

        [Required(ErrorMessage = "Por favor, insira a quantidade.")]
        public int SaidaQuantidade { get; set; }
        public DateOnly? EntradaData { get; set; }

        [ForeignKey("Usuario")]
        public string? UsuarioUserMat { get; set; }
        [ForeignKey("Produto")]
        public string? ProdutoProdEan { get; set; }
    }

}