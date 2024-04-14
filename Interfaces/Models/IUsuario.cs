using System.Collections.Generic;

namespace UGB.Interface
{
    public interface IUsuario
    {
        string UserMat { get; set; }
        string UserNome { get; set; }
        string UserEmail { get; set; }
        string UserSenha { get; set; }
        string UserDepartamento { get; set; }
    }

    public interface IUsuarioLogin
    {
        string UserMat { get; set; }
        string UserSenha { get; set; }

    }
}
