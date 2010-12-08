using System;

namespace Braintree.Testing {
    public class MockCreditCard : CreditCard {
        private static int _id = 0;

        public static MockCreditCard Create() {
            return Create((_id++).ToString());
        }

        public static MockCreditCard Create(string customerId) {
            return new MockCreditCard() { CustomerId = customerId };
        }

        public static MockCreditCard FromRequest(string customerId, CreditCardRequest request) {
            var number = request.Number;
            var bin = number != null && number.Length >= 6 ? number.Substring(6) : null;
            var lastFour = number != null && number.Length >= 4 ? number.Substring(number.Length - 5, 4) : null;
            var cc = new MockCreditCard() {
                BillingAddress = MockAddress.FromRequest(customerId, request.BillingAddress),
                Bin = bin,
                CardholderName = request.CardholderName,
                CardType = CreditCardCardType.VISA,
                CreatedAt = DateTime.UtcNow,
                CustomerId = customerId,
                ExpirationMonth = request.ExpirationMonth,
                ExpirationYear = request.ExpirationYear,
                IsDefault = request.Options.MakeDefault?? false,
                LastFour = lastFour,
            };
            if(!string.IsNullOrEmpty(request.ExpirationDate)) {
                cc.ExpirationDate = request.ExpirationDate;
            }
            return cc;
        }

        private MockCreditCard() { }

        public MockCreditCard WithBin( string bin) {
            return this;
        }
        public MockCreditCard WithCardholderName( string cardholderName) {
            return this;
        }
        public MockCreditCard WithCardType( CreditCardCardType cardType) {
            return this;
        }
        public MockCreditCard WithCreatedAt( DateTime? createdAt) {
            return this;
        }
        public MockCreditCard WithIsDefault( bool? ssDefault) {
            return this;
        }
        public MockCreditCard WithIsExpired( bool? isExpired) {
            return this;
        }
        public MockCreditCard WithCustomerLocation( CreditCardCustomerLocation customerLocation) {
            return this;
        }
        public MockCreditCard WithLastFour( string lastFour) {
            return this;
        }
        public MockCreditCard WithSubscription(MockSubscription subscription) {
            return this;
        }
        public MockCreditCard WithToken( string token) {
            return this;
        }
        public MockCreditCard WithUpdatedAt( DateTime? updatedAt) {
            return this;
        }
        public MockCreditCard WithBillingAddress( MockAddress billingAddress) {
            return this;
        }
        public MockCreditCard WithExpirationMonth( string expirationMonth) {
            return this;
        }
        public MockCreditCard WithExpirationYear(string expirationYear) {
            return this;
        }

    }
}