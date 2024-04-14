using System.Collections.Generic;
namespace UGB.Interface
{
    public interface IFactory<T>
    {
        T Create();
    }
}
