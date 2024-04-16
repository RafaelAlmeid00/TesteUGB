using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UGB.Interface;

namespace UGB.Data
{
    public class PedidoInterno : IPedidoInterno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; } = 0;
        [Required(ErrorMessage = "Por favor, insira a quantidade.")]
        public int PedidoQuantidade { get; set; } = 0;

        [Required(ErrorMessage = "Por favor, insira a data.")]
        public DateOnly PedidoData = DateOnly.FromDateTime(DateTime.Today);

        [ForeignKey("Usuario")]
        public string? UsuarioUserMat { get; set; } = null;

        [ForeignKey("Produto")]
        public string? ProdutoProdEan { get; set; } = null;
        [ForeignKey("Serviço")]
        public int? ServicoServId { get; set; } = null;
        public string? ServicoObservação { get; set; } = null;
        [NotMapped]
        public string? SelectValue { get; set; }
        [NotMapped]
        public string? ServicoNome { get; set; }
        [NotMapped]
        public string? ProdutoNome { get; set; }

    }

}