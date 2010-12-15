using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Braintree.Testing {
    public class MockGateway : BraintreeGateway {

        public static MockGatewayBuilder Configure() {
            return new MockGatewayBuilder();
        }

        private readonly Interceptor _interceptor;

        internal MockGateway(Interceptor interceptor)
        {
            _interceptor = interceptor;
        }

        public override CustomerGateway Customer {
            get {
                return new MockCustomerGateway(_interceptor);
            }
        }

        public void Verify() {
            _interceptor.Verify();
        }
    }
}
