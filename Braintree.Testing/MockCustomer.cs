using System;
using System.Collections.Generic;

namespace Braintree.Testing {
    public class MockCustomer : Customer {

        private static int _id = 0;

        public static MockCustomer Create() {
            return Create((_id++).ToString());
        }

        public static MockCustomer Create(string id) {
            return new MockCustomer() { Id = id };
        }

        public static MockCustomer FromRequest(CustomerRequest request) {
            return new MockCustomer() {

            };
        }

        private MockCustomer() { }

        public MockCustomer WithFirstName(String firstName) {
            return this;
        }
        public MockCustomer WithLastName(string lastName) {
            return this;
        }
        public MockCustomer WithCompany(string company) {
            return this;
        }
        public MockCustomer WithEmail(string email) {
            return this;
        }
        public MockCustomer WithPhone(string phone) {
            return this;
        }
        public MockCustomer WithFax(string fax) {
            return this;
        }
        public MockCustomer WithWebsite(string website) {
            return this;
        }
        public MockCustomer WithCreatedAt(DateTime? createdAt) {
            return this;
        }
        public MockCustomer WithUpdatedAt(DateTime? updatedAt) {
            return this;
        }
        public MockCustomer WithCreditCard(CreditCard creditCard) {
            return this;
        }
        public MockCustomer WithoutCreditCards() {
            return this;
        }
        public MockCustomer WithAddress(Address addresses) {
            return this;
        }
        public MockCustomer WithoutAddress() {
            return this;
        }
        public MockCustomer WithCustomFields(Dictionary<String, string> CustomFields) {
            return this;
        }
        public MockResult<Customer> ToResult() {
            return new MockResult<Customer>(this);
        }
    }
}