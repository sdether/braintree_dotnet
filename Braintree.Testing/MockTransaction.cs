using System;
using System.Collections.Generic;

namespace Braintree.Testing {
    public class MockTransaction: Transaction {

        private static int _id = 0;

        public static MockTransaction Create() {
            return Create((_id++).ToString());
        }

       public static MockTransaction Create(string id) {
            return new MockTransaction() {Id = id};
        }

        public static MockTransaction FromRequest(TransactionRequest request) {
            return new MockTransaction() {

            };
        }

        private MockTransaction() {}

        public MockTransaction WithAddOn(MockAddOn addOn) {
            return this;
        }
        public MockTransaction WithAmount( decimal? amount) {
            return this;
        }
        public MockTransaction WithAvsErrorResponseCode(string code) {
            return this;
        }
        public MockTransaction WithAvsPostalCodeResponseCode( string code) {
            return this;
        }
        public MockTransaction WithAvsStreetAddressResponseCode( string code) {
            return this;
        }
        public MockTransaction WithBillingAddress( MockAddress address) {
            return this;
        }
        public MockTransaction WithCreatedAt( DateTime? createdAt) {
            return this;
        }
        public MockTransaction WithCreditCard( MockCreditCard creditCard) {
            return this;
        }
        public MockTransaction WithCurrencyIsoCode( string code) {
            return this;
        }
        public MockTransaction WithCustomer( MockCustomer customer) {
            return this;
        }
        public MockTransaction WithCvvResponseCode( string code) {
            return this;
        }
        public MockTransaction WithDiscount( MockDiscount discount) {
            return this;
        }
        public MockTransaction WithGatewayRejectionReason( TransactionGatewayRejectionReason reason) {
            return this;
        }
        public MockTransaction WithMerchantAccountId(string merchantAccountId) {
            return this;
        }
        public MockTransaction WithOrderId( string orderId) {
            return this;
        }
        public MockTransaction WithProcessorAuthorizationCode( string code) {
            return this;
        }
        public MockTransaction WithProcessorResponseCode( string code) {
            return this;
        }
        public MockTransaction WithProcessorResponseText( string response) {
            return this;
        }
        public MockTransaction WithRefundedTransactionId( string refundedTransactionId) {
            return this;
        }
        public MockTransaction WithRefundIds( IEnumerable<string> refundIds) {
            return this;
        }
        public MockTransaction WithSettlementBatchId( string settlementBatchId) {
            return this;
        }
        public MockTransaction WithShippingAddress( MockAddress shippingAddress) {
            return this;
        }
        public MockTransaction WithStatus( TransactionStatus status) {
            return this;
        }
        public MockTransaction WithStatusHistory( StatusEvent[] statusHistory) {
            return this;
        }
        public MockTransaction WithSubscriptionId( string subscriptionId) {
            return this;
        }
        public MockTransaction WithTransactionType(TransactionType type) {
            return this;
        }
        public MockTransaction WithUpdatedAt( DateTime? updatedAt) {
            return this;
        }
        public MockTransaction WithCustomFields( Dictionary<string, string> customFields) {
            return this;
        }
    }
}