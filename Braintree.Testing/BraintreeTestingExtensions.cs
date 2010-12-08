using System;

namespace Braintree.Testing {
    public static class BraintreeTestingExtensions {

        public static Result<Customer> ToCustomer(this CustomerRequest request) {
            return request.ToCustomer((r, t) => { });
        }

        public static Result<Customer> ToCustomer(this CustomerRequest request, Action<CustomerRequest, MockCustomer> initCallback) {
            var target = MockCustomer.FromRequest(request);
            initCallback(request, target);
            return target.ToResult();
        }

        public static Result<Subscription> ToSubscription(this SubscriptionRequest request) {
            return request.ToSubscription((r, t) => { });
        }

        public static Result<Subscription> ToSubscription(this SubscriptionRequest request, Action<SubscriptionRequest, MockSubscription> initCallback) {
            var target = MockSubscription.FromRequest(request);
            initCallback(request, target);
            return target.ToResult();
        }

        public static Result<Transaction> ToTransaction(this TransactionRequest request) {
            return request.ToTransaction((r, t) => { });
        }

        public static Result<Transaction> ToTransaction(this TransactionRequest request, Action<TransactionRequest, MockTransaction> initCallback) {
            var target = MockTransaction.FromRequest(request);
            initCallback(request, target);
            return target.ToResult();
        }
    }
}