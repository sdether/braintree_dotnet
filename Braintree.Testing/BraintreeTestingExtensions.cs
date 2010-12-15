using System;

namespace Braintree.Testing {
    public static class BraintreeTestingExtensions {

        public static MockResult<Customer> ToCustomer(this CustomerRequest request) {
            return request.ToCustomer(t => { });
        }

        public static MockResult<Customer> ToCustomer(this CustomerRequest request, Action<MockCustomer> initCallback) {
            var target = MockCustomer.FromRequest(request);
            initCallback(target);
            return target.ToResult();
        }

        public static MockResult<Subscription> ToSubscription(this SubscriptionRequest request) {
            return request.ToSubscription(t => { });
        }

        public static MockResult<Subscription> ToSubscription(this SubscriptionRequest request, Action<MockSubscription> initCallback) {
            var target = MockSubscription.FromRequest(request);
            initCallback(target);
            return target.ToResult();
        }

        public static MockResult<Transaction> ToTransaction(this TransactionRequest request) {
            return request.ToTransaction(t => { });
        }

        public static MockResult<Transaction> ToTransaction(this TransactionRequest request, Action<MockTransaction> initCallback) {
            var target = MockTransaction.FromRequest(request);
            initCallback(target);
            return target.ToResult();
        }
    }
}