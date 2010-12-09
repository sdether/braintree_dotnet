using System;

namespace Braintree.Testing {
    public class MockGatewaySetup {
        private readonly MockGateway _gateway;

        internal MockGatewaySetup(MockGateway gateway) {
            _gateway = gateway;
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

        public MockGateway ReturnsVoid() {
            return _gateway;
        }

        public MockGateway ReturnsCustomerResult(Func<CustomerRequest, Result<Customer>> request) {
            return _gateway;
        }

        public MockGateway ReturnsDefault() {
            return _gateway;
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