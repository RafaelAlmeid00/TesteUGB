using UGB.Interface;

namespace UGB.Data;
public class Usuario : IUsuario
{
    public Usuario()
    {
        UserMat = null;
        UserNome = null;
        UserEmail = null;
        UserSenha = null;
        UserDepartamento = null;
    }

    public string? UserMat { get; set; }
    public string? UserNome { get; set; }
    public string? UserEmail { get; set; }
    public string? UserSenha { get; set; }
    public string? UserDepartamento { get; set; }
}


public class UsuarioLogin : IUsuarioLogin
{
    public required string UserMat { get; set; }
    public required string UserSenha { get; set; }
}
