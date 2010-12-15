namespace Braintree.Testing {
    public class MockTransparentRedirectGateway : TransparentRedirectGateway {
        private readonly ICallbackProvider _callbackProvider;

        public MockTransparentRedirectGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }
        public override Result<CreditCard> ConfirmCreditCard(string queryString) {
            return _callbackProvider.Invoke<Result<CreditCard>>(queryString);
        }
        public override Result<Customer> ConfirmCustomer(string queryString) {
            return _callbackProvider.Invoke<Result<Customer>>(queryString);
        }
        public override Result<Transaction> ConfirmTransaction(string queryString) {
            return _callbackProvider.Invoke<Result<Transaction>>(queryString);
        }
    }
}