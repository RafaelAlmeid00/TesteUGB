using System.Collections.Generic;

namespace UGB.Interface
{
    public interface IUsuario
    {
        int UserMat { get; set; }
        string UserNome { get; set; }
        string UserEmail { get; set; }
        string UserSenha { get; set; }
        string UserDepartamento { get; set; }
    }

    public interface IUsuarioLogin
    {
        int UserMat { get; set; }
        string UserSenha { get; set; }

    }
}
