using System.Reflection;

namespace Braintree.Testing {
    internal interface ICallbackProvider
    {
        object Invoke(params object[] args);
    }
}