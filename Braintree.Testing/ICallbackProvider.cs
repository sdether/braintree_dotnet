using System.Reflection;

namespace Braintree.Testing {
    public interface ICallbackProvider
    {
        T Invoke<T>(params object[] args);
        void Invoke(params object[] args);
    }
}