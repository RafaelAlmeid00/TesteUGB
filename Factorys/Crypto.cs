
using UGB.Data;
using UGB.Interface;
using UGB.Services;

namespace UGB.Factory
{
    public class CryptoFactory : IFactory<ICrypto>
    {
        private readonly string? _hash;
        private readonly string _password;
        public CryptoFactory(string hash, string password)
        {
            _hash = hash;
            _password = password;
        }
        public ICrypto Create()
        {
            return new Crypto(_hash, _password);
        }
    }
}