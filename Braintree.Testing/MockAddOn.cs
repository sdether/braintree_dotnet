using System;
using System.Collections.Generic;

namespace Braintree.Testing {
    public class MockAddOn : AddOn {

        private static int _id = 0;

        public static MockAddOn Create() {
            return Create((_id++).ToString());
        }

        public static MockAddOn Create(string id) {
            return new MockAddOn() { Id = id };
        }

        public static List<AddOn> FromRequest(AddOnsRequest request) {
            var list = new List<AddOn>();
            foreach(var addOn in request.Add) {
                list.Add(FromRequest(addOn));
            }
            foreach(var addOn in request.Update) {
                list.Add(FromRequest(addOn));
            }
            return list;
        }

        public static MockAddOn FromRequest(AddAddOnRequest request) {
            return new MockAddOn() {
                Amount = request.Amount,
                Id = (_id++).ToString(),
                NeverExpires = request.NeverExpires,
                NumberOfBillingCycles = request.NumberOfBillingCycles,
                Quantity = request.Quantity
            };
        }

        public static MockAddOn FromRequest(UpdateAddOnRequest request) {
            return new MockAddOn() {
                Amount = request.Amount,
                Id = (_id++).ToString(),
                NeverExpires = request.NeverExpires,
                NumberOfBillingCycles = request.NumberOfBillingCycles,
                Quantity = request.Quantity
            };
        }

        private MockAddOn() { }

        public MockAddOn WithAmount(decimal? amount) {
            Amount = amount;
            return this;
        }
        public MockAddOn WithNeverExpires(bool? neverExpires) {
            NeverExpires = neverExpires;
            return this;
        }
        public MockAddOn WithNumberOfBillingCycles(int? cycles) {
            NumberOfBillingCycles = cycles;
            return this;
        }
        public MockAddOn WithQuantity(int? quantity) {
            Quantity = quantity;
            return this;
        }
    }
}