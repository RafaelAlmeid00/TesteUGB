using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data
{

    public class EntradaEstoque : IEntradaEstoque
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntradaId { get; set; }
        [Required(ErrorMessage = "Por favor, insira a NF.")]
        public string EntradaNf { get; set; } = null!;
        [Required(ErrorMessage = "Por favor, insira o Depósito.")]
        public string? EntradaDeposito { get; set; }
        public int? EntradaQuantidade { get; set; }
        public DateOnly? EntradaData { get; set; }
        [ForeignKey("Usuario")]
        public string? UsuarioUserMat { get; set; }
        [ForeignKey("Produto")]
        public string? ProdutoProdEan { get; set; }

    }
}