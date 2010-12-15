using System;
using System.Diagnostics;

namespace Braintree.Testing {
    public class MockCustomerGateway : CustomerGateway {
        private readonly ICallbackProvider _callbackProvider;

        internal MockCustomerGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }

        public override ResourceCollection<Customer> All() {
            return (ResourceCollection<Customer>)_callbackProvider.Invoke();
        }
    }
}