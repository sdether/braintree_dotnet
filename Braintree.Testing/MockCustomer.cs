using System;
using System.Collections.Generic;
using System.Linq;

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
            var id = request.Id;
            if(string.IsNullOrEmpty(id)) {
                id = (_id++).ToString();
            }
            var mockCustomer = new MockCustomer() {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName= request.LastName,
                Company= request.Company,
                Email= request.Email,
                Phone= request.Phone,
                Fax= request.Fax,
                Website = request.Website,
                CustomFields = request.CustomFields
            };
            if(request.CreditCard != null) {
                mockCustomer.WithCreditCard(MockCreditCard.FromRequest(id, request.CreditCard));
            }
            return mockCustomer;
        }

        private MockCustomer() { }

        public MockCustomer WithId(string id) {
            Id = id;
            return this;
        }

        public MockCustomer WithFirstName(string firstName) {
            FirstName = firstName;
            return this;
        }
        public MockCustomer WithLastName(string lastName) {
            LastName = lastName;
            return this;
        }
        public MockCustomer WithCompany(string company) {
            Company = company;
            return this;
        }
        public MockCustomer WithEmail(string email) {
            Email = email;
            return this;
        }
        public MockCustomer WithPhone(string phone) {
            Phone = phone;
            return this;
        }
        public MockCustomer WithFax(string fax) {
            Fax = fax;
            return this;
        }
        public MockCustomer WithWebsite(string website) {
            Website = website;
            return this;
        }
        public MockCustomer WithCreatedAt(DateTime? createdAt) {
            CreatedAt = createdAt;
            return this;
        }
        public MockCustomer WithUpdatedAt(DateTime? updatedAt) {
            UpdatedAt = updatedAt;
            return this;
        }
        public MockCustomer WithCreditCard(CreditCard creditCard) {
            var list = CreditCards.ToList();
            list.Add(creditCard);
            CreditCards = list.ToArray();
            return this;
        }
        public MockCustomer WithoutCreditCards() {
            CreditCards = null;
            return this;
        }
        public MockCustomer WithAddress(Address address) {
            var list = Addresses.ToList();
            list.Add(address);
            Addresses = list.ToArray();
            return this;
        }
        public MockCustomer WithoutAddress() {
            Addresses = null;
            return this;
        }
        public MockCustomer WithCustomFields(Dictionary<string, string> customFields) {
            CustomFields = customFields;
            return this;
        }
        public MockResult<Customer> ToResult() {
            return new MockResult<Customer>(this);
        }
    }
}