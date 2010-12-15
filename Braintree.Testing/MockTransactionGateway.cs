namespace Braintree.Testing {
    public class MockTransactionGateway : TransactionGateway {
        private readonly ICallbackProvider _callbackProvider;

        public MockTransactionGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }
        public override Result<Transaction> ConfirmTransparentRedirect(string queryString) {
            return _callbackProvider.Invoke<Result<Transaction>>(queryString);
        }
        public override Result<Transaction> Credit(TransactionRequest request) {
            return _callbackProvider.Invoke<Result<Transaction>>(request);
        }
        public override string CreditTrData(TransactionRequest trData, string redirectURL) {
            return _callbackProvider.Invoke<string>(trData, redirectURL);
        }
        public override Transaction Find(string id) {
            return _callbackProvider.Invoke<Transaction>(id);
        }
        public override Result<Transaction> Refund(string id) {
            return _callbackProvider.Invoke<Result<Transaction>>(id);
        }
        public override Result<Transaction> Refund(string id, decimal amount) {
            return _callbackProvider.Invoke<Result<Transaction>>(id, amount);
        }
        public override Result<Transaction> Sale(TransactionRequest request) {
            return _callbackProvider.Invoke<Result<Transaction>>(request);
        }
        public override string SaleTrData(TransactionRequest trData, string redirectURL) {
            return _callbackProvider.Invoke<string>(trData, redirectURL);
        }
        public override ResourceCollection<Transaction> Search(TransactionSearchRequest query) {
            return _callbackProvider.Invoke<ResourceCollection<Transaction>>(query);
        }
        public override Result<Transaction> SubmitForSettlement(string id) {
            return _callbackProvider.Invoke<Result<Transaction>>(id);
        }
        public override Result<Transaction> SubmitForSettlement(string id, decimal amount) {
            return _callbackProvider.Invoke<Result<Transaction>>(id, amount);
        }
        public override string TransparentRedirectURLForCreate() {
            return _callbackProvider.Invoke<string>();
        }
        public override Result<Transaction> Void(string id) {
            return _callbackProvider.Invoke<Result<Transaction>>(id);
        }
    }
}