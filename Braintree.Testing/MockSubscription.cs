using System;

namespace Braintree.Testing {
    public class MockSubscription : Subscription {

        private static int _id = 0;

        public static MockSubscription Create() {
            return Create((_id++).ToString());
        }

        public static MockSubscription Create(string id) {
            return new MockSubscription() { Id = id };
        }

        public static MockSubscription FromRequest(SubscriptionRequest request) {
            return new MockSubscription() {
                AddOns = MockAddOn.FromRequest(request.AddOns),
                BillingDayOfMonth = request.BillingDayOfMonth,
                Discounts = MockDiscount.FromRequest(request.Discounts),
                FirstBillingDate = request.FirstBillingDate,
                HasTrialPeriod = request.HasTrialPeriod,
                Id = request.Id,
                MerchantAccountId = request.MerchantAccountId,
                NeverExpires = request.NeverExpires,
                PaymentMethodToken = request.PaymentMethodToken,
                PlanId = request.PlanId,
                Price = request.Price,
                TrialDuration = request.TrialDuration,
                TrialDurationUnit = request.TrialDurationUnit,
            };
        }

        private MockSubscription() { }

        public MockSubscription WithAddOn(MockAddOn addOn) {
            return this;
        }
        public MockSubscription WithoutAddOns() {
            return this;
        }
        public MockSubscription WithBalance(decimal? balance) {
            return this;
        }
        public MockSubscription WithBillingDayOfMonth(int? day) {
            return this;
        }
        public MockSubscription WithBillingPeriodEndDate(DateTime? end) {
            return this;
        }
        public MockSubscription WithBillingPeriodStartDate(DateTime? start) {
            return this;
        }
        public MockSubscription WithDaysPastDue(int? pastDue) {
            return this;
        }
        public MockSubscription WithDiscount(MockDiscount discount) {
            return this;
        }
        public MockSubscription WithoutDiscount() {
            return this;
        }
        public MockSubscription WithFailureCount(int? failureCount) {
            return this;
        }
        public MockSubscription WithFirstBillingDate(DateTime? date) {
            return this;
        }
        public MockSubscription WithHasTrialPeriod(bool? hasTrialPeriod) {
            return this;
        }
        public MockSubscription WithMerchantAccountId(string merchantId) {
            return this;
        }
        public MockSubscription WithNeverExpires(bool? neverExpires) {
            return this;
        }
        public MockSubscription WithNextBillAmount(decimal? nextBillAmount) {
            return this;
        }
        public MockSubscription WithNextBillingDate(DateTime? next) {
            return this;
        }
        public MockSubscription WithNextBillingPeriodAmount(decimal? amount) {
            return this;
        }
        public MockSubscription WithNumberOfBillingCycles(int? billingCycles) {
            return this;
        }
        public MockSubscription WithPaidThroughDate(DateTime? date) {
            return this;
        }
        public MockSubscription WithPaymentMethodToken(string token) {
            return this;
        }
        public MockSubscription WithPlanId(string planId) {
            return this;
        }
        public MockSubscription WithPrice(decimal? price) {
            return this;
        }
        public MockSubscription WithStatus(SubscriptionStatus status) {
            return this;
        }
        public MockSubscription WithTransaction(MockTransaction transaction) {
            return this;
        }
        public MockSubscription WithTrialDuration(int? duration) {
            return this;
        }
        public MockSubscription WithTrialDurationUnit(SubscriptionDurationUnit unit) {
            return this;
        }
        public MockResult<Subscription> ToResult() {
            return new MockResult<Subscription>(this);
        }
    }
}
