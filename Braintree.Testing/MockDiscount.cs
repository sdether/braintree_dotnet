using System;
using System.Collections.Generic;

namespace Braintree.Testing {
    public class MockDiscount : Discount {

        private static int _id = 0;

        public static MockDiscount Create() {
            return Create((_id++).ToString());
        }

        public static MockDiscount Create(string id) {
            return new MockDiscount() { Id = id };
        }

        public static List<Discount> FromRequest(DiscountsRequest request) {
            var list = new List<Discount>();
            foreach(var discount in request.Add) {
                list.Add(FromRequest(discount));
            }
            foreach(var discount in request.Update) {
                list.Add(FromRequest(discount));
            }
            return list;
        }

        public static MockDiscount FromRequest(AddDiscountRequest request) {
            return new MockDiscount() {
                Amount = request.Amount,
                Id = (_id++).ToString(),
                NeverExpires = request.NeverExpires,
                NumberOfBillingCycles = request.NumberOfBillingCycles,
                Quantity = request.Quantity,
            };
        }

        public static MockDiscount FromRequest(UpdateDiscountRequest request) {
            return new MockDiscount() {
                Amount = request.Amount,
                Id = (_id++).ToString(),
                NeverExpires = request.NeverExpires,
                NumberOfBillingCycles = request.NumberOfBillingCycles,
                Quantity = request.Quantity,
            };
        }

        private MockDiscount() {}

        public MockDiscount WithAmount(decimal? amount) {
            Amount = amount;
            return this;
        }
        public MockDiscount WithNeverExpires(bool? neverExpires) {
            NeverExpires = neverExpires;
            return this;
        }
        public MockDiscount WithNumberOfBillingCycles(int? cycles) {
            NumberOfBillingCycles = cycles;
            return this;
        }
        public MockDiscount WithQuantity(int? quantity) {
            Quantity = quantity;
            return this;
        }
    }
}