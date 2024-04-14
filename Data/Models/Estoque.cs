using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data
{
    public class Estoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstoqueId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [StringLength(60)]
        [ForeignKey("Produto")]
        public required string ProdutoProdEan { get; set; }

        public required Produto Produto { get; set; }
    }
}
