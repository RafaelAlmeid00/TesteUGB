using UGB.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UGB.Data;

public partial class Serviço : IServiço
{
    [Key]
    public int ServId { get; set; }
    [Required(ErrorMessage = "Por favor, insira o nome.")]
    public string ServNome { get; set; } = null!;
    [Required(ErrorMessage = "Por favor, insira a descrição.")]

    public string ServDescricao { get; set; } = null!;
    [Required(ErrorMessage = "Por favor, insira o prazo.")]

    public string ServPrazo { get; set; } = null!;
    [ForeignKey("Usuario")]
    public int UsuarioUserMat { get; set; }

    [ForeignKey("Fornecedor")]
    public int FornecedorFornecedorCnpj { get; set; }

}
