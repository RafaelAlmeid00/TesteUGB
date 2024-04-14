using UGB.Interface;

namespace UGB.Data;
public class Usuario : IUsuario
{
    public Usuario()
    {
        UserMat = 0;
        UserNome = "admin";
        UserEmail = "admin";
        UserSenha = "admin";
        UserDepartamento = "admin";
    }

    public int UserMat { get; set; }
    public string UserNome { get; set; }
    public string UserEmail { get; set; }
    public string UserSenha { get; set; }
    public string UserDepartamento { get; set; }
}


public class UsuarioLogin : IUsuarioLogin
{
    public int UserMat { get; set; }
    public required string UserSenha { get; set; }
}
