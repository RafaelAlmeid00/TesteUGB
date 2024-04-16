using System.ComponentModel.DataAnnotations;
using UGB.Interface;

namespace UGB.Data;
public class Usuario : IUsuario
{
    [Key]
    [MinLength(14, ErrorMessage = "A matricula deve ter 14 caracteres.")]
    public string? UserMat { get; set; } = null;

    [Required(ErrorMessage = "Por favor, insira o nome.")]
    public string? UserNome { get; set; } = null;
    [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
    [Required(ErrorMessage = "Por favor, insira o email.")]
    public string? UserEmail { get; set; } = null;
    [Required(ErrorMessage = "Por favor, insira a senha.")]
    public string? UserSenha { get; set; } = null;
    [Required(ErrorMessage = "Por favor, insira o departamento.")]
    public string? UserDepartamento { get; set; } = null;
}


public class UsuarioLogin : IUsuarioLogin
{
    [Required(ErrorMessage = "Por favor, insira a matricula.")]
    [StringLength(14, ErrorMessage = "A matricula deve ter 14 caracteres.")]
    [MinLength(1, ErrorMessage = "A matricula não pode ser nula.")]
    public required string UserMat { get; set; }
    [Required(ErrorMessage = "Por favor, insira a senha.")]
    [MinLength(1, ErrorMessage = "A senha não pode ser nula.")]
    public required string UserSenha { get; set; }
}
