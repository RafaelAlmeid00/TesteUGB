using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data
{
    public class Estoque : IEstoque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstoqueId { get; set; }
        public int? Quantidade { get; set; }

        [ForeignKey("Produto")]
        public string? ProdutoProdEan { get; set; }
        [NotMapped]
        public string? EstoqueMinimo { get; set; }
        [NotMapped]
        public string? StatusEstoque { get; set; }
        [NotMapped]
        public string? ProdutoNome { get; set; }
    }

}
