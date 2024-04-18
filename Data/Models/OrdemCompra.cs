using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data
{
    public class OrdemCompra : IOrdemCompra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdemId { get; set; }
        [Required(ErrorMessage = "Por favor, insira a quantidade.")]
        public int OrdemQuantidade { get; set; }
        public decimal OrdemPrecototal { get; set; }
        [ForeignKey("PedidoInterno")]
        public int? PedidoInternoPedidoId { get; set; }
        [ForeignKey("Usuario")]
        public string? PedidoInternoUsuarioUserMat { get; set; }
        [NotMapped]
        public string? ServicoNome { get; set; }
        [NotMapped]
        public string? ProdutoNome { get; set; }
        [NotMapped]
        public string? FornecedorNome { get; set; }
    }
}