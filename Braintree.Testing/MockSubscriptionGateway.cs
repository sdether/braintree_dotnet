namespace Braintree.Testing {
    public class MockSubscriptionGateway : SubscriptionGateway {
        private readonly ICallbackProvider _callbackProvider;

        public MockSubscriptionGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }

        public override Result<Subscription> Cancel(string id) {
            return _callbackProvider.Invoke<Result<Subscription>>(id);
        }
        public override Result<Subscription> Create(SubscriptionRequest request) {
            return _callbackProvider.Invoke<Result<Subscription>>(request);
        }
        public override Subscription Find(string id) {
            return _callbackProvider.Invoke<Subscription>(id);
        }
        public override ResourceCollection<Subscription> Search(SearchDelegate searchDelegate) {
            return _callbackProvider.Invoke<ResourceCollection<Subscription>>(searchDelegate);
        }
        public override ResourceCollection<Subscription> Search(SubscriptionSearchRequest query) {
            return _callbackProvider.Invoke<ResourceCollection<Subscription>>(query);
        }
        public override Result<Subscription> Update(string id, SubscriptionRequest request) {
            return _callbackProvider.Invoke<Result<Subscription>>(id, request);
        }
    }
}