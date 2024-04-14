
using UGB.Data;
using UGB.Interface;

namespace UGB.Factory
{
    public class ErrorViewFactory : IFactory<IErrorView>
    {
        public IErrorView Create()
        {
            return new ErrorView();
        }
    }
}