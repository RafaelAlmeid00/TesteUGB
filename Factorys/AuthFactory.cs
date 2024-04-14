
using UGB.Data;
using UGB.Interface;
using UGB.Services;

namespace UGB.Factory
{
    public class AuthFactory : IFactory<IAuth>
    {
        private readonly IUsuario _usuario;
        public AuthFactory(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public IAuth Create()
        {
            return new Auth(_usuario);
        }
    }
}