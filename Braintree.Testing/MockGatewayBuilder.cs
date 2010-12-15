using System;
using System.Linq.Expressions;

namespace Braintree.Testing {
    public class MockGatewayBuilder {
        private readonly Interceptor _interceptor;

        public MockGatewayBuilder()
        {
            _interceptor = new Interceptor();
        }

        public MockGatewaySetup Setup(Expression<Action<BraintreeGateway>> method) {
            return new MockGatewaySetup(this);
        }

        public MockGateway Build()
        {
            return new MockGateway(_interceptor);
        }
    }
}