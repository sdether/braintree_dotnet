using System;

namespace Braintree.Testing {
    public class MockGatewaySetup {
        private readonly MockGatewayBuilder _builder;

        internal MockGatewaySetup(MockGatewayBuilder builder) {
            _builder = builder;
        }

        public MockGatewaySetup ExpectNone() {
            return this;
        }

        public MockGatewaySetup ExpectOnce() {
            return this;
        }

        public MockGatewaySetup ExpectMany(int times) {
            return this;
        }

        public MockGatewayBuilder ReturnsVoid() {
            return _builder;
        }

        public MockGatewayBuilder ReturnsCustomerResult(Func<CustomerRequest, Result<Customer>> request) {
            return _builder;
        }

        public MockGatewayBuilder ReturnsDefault() {
            return _builder;
        }

        public MockGatewaySetup ValidateArguments<T>(Func<T, bool> args) {
            return this;
        }

        public MockGatewaySetup ValidateArguments<T1, T2>(Func<T1, T2, bool> args) {
            return this;
        }

        public MockGatewaySetup ValidateArguments<T1, T2, T3>(Func<T1, T2, T3, bool> args) {
            return this;
        }
    }
}