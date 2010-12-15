using System;

namespace Braintree.Testing {
    public class MockCreditCardGateway : CreditCardGateway {
        private readonly ICallbackProvider _callbackProvider;

        public MockCreditCardGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }

        public override Result<CreditCard> ConfirmTransparentRedirect(string queryString) {
            return _callbackProvider.Invoke<Result<CreditCard>>(queryString);
        }
        public override Result<CreditCard> Create(CreditCardRequest request) {
            return _callbackProvider.Invoke<Result<CreditCard>>(request);
        }
        public override void Delete(string token) {
            _callbackProvider.Invoke(token);
        }
        public override ResourceCollection<CreditCard> Expired() {
            return _callbackProvider.Invoke<ResourceCollection<CreditCard>>();
        }
        public override ResourceCollection<CreditCard> ExpiringBetween(DateTime start, DateTime end) {
            return _callbackProvider.Invoke<ResourceCollection<CreditCard>>(start,end);
        }
        public override CreditCard Find(string token) {
            return _callbackProvider.Invoke<CreditCard>(token);
        }
        public override string TransparentRedirectURLForCreate() {
            return _callbackProvider.Invoke<string>();
        }
        public override string TransparentRedirectURLForUpdate() {
            return _callbackProvider.Invoke<string>();
        }
        public override Result<CreditCard> Update(string token, CreditCardRequest request) {
            return _callbackProvider.Invoke<Result<CreditCard>>(token, request);
        }
    }
}