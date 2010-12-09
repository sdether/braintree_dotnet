using System;

namespace Braintree.Testing {
    public class MockCustomerGateway : CustomerGateway {
        internal MockCustomerGateway(ICallbackProvider callbackProvider) {
            throw new NotImplementedException();
        }

        public override ResourceCollection<Customer> All() {
            return base.All();
        }
    }
}