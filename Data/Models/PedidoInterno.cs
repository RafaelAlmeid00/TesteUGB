using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UGB.Interface;

namespace UGB.Data
{
    public class PedidoInterno : IPedidoInterno
    {
        [Key]
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
        [Required(ErrorMessage = "Por favor, insira a observação.")]
        public string? ServicoObservação { get; set; } = null;
        public virtual Usuario UsuarioUserMatNavigation { get; set; } = null!;
    }

}