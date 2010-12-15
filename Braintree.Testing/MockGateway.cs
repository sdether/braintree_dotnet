namespace Braintree.Testing {
    public class MockGateway : BraintreeGateway {

        public static MockGatewayBuilder Configure() {
            return new MockGatewayBuilder();
        }

        private readonly Interceptor _interceptor;

        internal MockGateway(Interceptor interceptor) {
            _interceptor = interceptor;
        }

        public override CustomerGateway Customer { get { return new MockCustomerGateway(_interceptor); } }
        public override AddressGateway Address { get { return new MockAddressGateway(_interceptor); } }
        public override CreditCardGateway CreditCard { get { return new MockCreditCardGateway(_interceptor); } }
        public override SubscriptionGateway Subscription { get { return new MockSubscriptionGateway(_interceptor); } }
        public override TransactionGateway Transaction { get { return new MockTransactionGateway(_interceptor); } }
        public override TransparentRedirectGateway TransparentRedirect { get { return new MockTransparentRedirectGateway(_interceptor); } }
        public void Verify() { _interceptor.Verify(); }
    }
}
