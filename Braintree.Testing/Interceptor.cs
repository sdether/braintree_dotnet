using System;
using System.Reflection;

namespace Braintree.Testing
{
    internal class Interceptor : ICallbackProvider{

        public object Invoke(params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}