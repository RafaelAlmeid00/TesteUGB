
using UGB.Data;
using UGB.Interface;
using UGB.Services;

namespace UGB.Factory
{
    public class UsuarioFactory : IFactory<IUsuario>
    {

        public IUsuario Create()
        {
            return new Usuario();
        }
    }
}
