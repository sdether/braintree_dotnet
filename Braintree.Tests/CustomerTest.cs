﻿using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Braintree;

namespace Braintree.Tests
{
    [TestFixture]
    class CustomerTest
    {
        private BraintreeGateway gateway;

        [SetUp]
        public void Setup()
        {
            gateway = new BraintreeGateway
            {
                Environment = Environment.DEVELOPMENT,
                MerchantID = "integration_merchant_id",
                PublicKey = "integration_public_key",
                PrivateKey = "integration_private_key"
            };
        }

        [Test]
        public void Find_FindsCustomerWithGivenId()
        {
            String id = Guid.NewGuid().ToString();
            var createRequest = new CustomerRequest
            {
                ID = id,
                FirstName = "Michael",
                LastName = "Angelo",
                Company = "Some Company",
                Email = "hansolo64@compuserver.com",
                Phone = "312.555.1111",
                Fax = "312.555.1112",
                Website = "www.disney.com",
                CreditCard = new CreditCardRequest
                {
                    Number = "5105105105105100",
                    ExpirationDate = "05/12",
                    CVV = "123",
                    CardholderName = "Michael Angelo",
                    BillingAddress = new AddressRequest()
                    {
                        FirstName = "Mike",
                        LastName = "Smith",
                        Company = "Smith Co.",
                        StreetAddress = "1 W Main St",
                        ExtendedAddress = "Suite 330",
                        Locality = "Chicago",
                        Region = "IL",
                        PostalCode = "60622",
                        CountryName = "United States of America"
                    }
                }
            };

            Customer createdCustomer = gateway.Customer.Create(createRequest).Target;
            Customer customer = gateway.Customer.Find(createdCustomer.ID).Target;
            Assert.AreEqual(id, customer.ID);
            Assert.AreEqual("Michael", customer.FirstName);
            Assert.AreEqual("Angelo", customer.LastName);
            Assert.AreEqual("Some Company", customer.Company);
            Assert.AreEqual("hansolo64@compuserver.com", customer.Email);
            Assert.AreEqual("312.555.1111", customer.Phone);
            Assert.AreEqual("312.555.1112", customer.Fax);
            Assert.AreEqual("www.disney.com", customer.Website);
            Assert.AreEqual(DateTime.Now.Year, customer.CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.UpdatedAt.Year);
            Assert.AreEqual(1, customer.CreditCards.Length);
            Assert.AreEqual("510510", customer.CreditCards[0].Bin);
            Assert.AreEqual("5100", customer.CreditCards[0].LastFour);
            Assert.AreEqual("05", customer.CreditCards[0].ExpirationMonth);
            Assert.AreEqual("2012", customer.CreditCards[0].ExpirationYear);
            Assert.AreEqual("Michael Angelo", customer.CreditCards[0].CardholderName);
            Assert.AreEqual(DateTime.Now.Year, customer.CreditCards[0].CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.CreditCards[0].UpdatedAt.Year);
            Assert.AreEqual("Mike", customer.Addresses[0].FirstName);
            Assert.AreEqual("Smith", customer.Addresses[0].LastName);
            Assert.AreEqual("Smith Co.", customer.Addresses[0].Company);
            Assert.AreEqual("1 W Main St", customer.Addresses[0].StreetAddress);
            Assert.AreEqual("Suite 330", customer.Addresses[0].ExtendedAddress);
            Assert.AreEqual("Chicago", customer.Addresses[0].Locality);
            Assert.AreEqual("IL", customer.Addresses[0].Region);
            Assert.AreEqual("60622", customer.Addresses[0].PostalCode);
            Assert.AreEqual("United States of America", customer.Addresses[0].CountryName);
        }

        [Test]
        public void Find_RaisesIfIDIsInvalid()
        {
            Assert.Throws<NotFoundError>(() => gateway.Customer.Find("DOES_NOT_EXIST_999"));
        }

        [Test]
        public void Create_CanSetCustomFields()
        {
            var customFields = new Dictionary<String, String>();
            customFields.Add("store_me", "a custom value");
            var expectedCustomFields = new Dictionary<String, String>();
            expectedCustomFields.Add("store-me", "a custom value");
            var createRequest = new CustomerRequest()
            {
                CustomFields = customFields
            };

            Customer customer = gateway.Customer.Create(createRequest).Target;
            Assert.AreEqual(expectedCustomFields, customer.CustomFields);
        }

        [Test]
        public void Create_CreatesCustomerWithSpecifiedValues()
        {
            var createRequest = new CustomerRequest()
            {
                FirstName = "Michael",
                LastName = "Angelo",
                Company = "Some Company",
                Email = "hansolo64@compuserver.com",
                Phone = "312.555.1111",
                Fax = "312.555.1112",
                Website = "www.disney.com"
            };

            Customer customer = gateway.Customer.Create(createRequest).Target;
            Assert.AreEqual("Michael", customer.FirstName);
            Assert.AreEqual("Angelo", customer.LastName);
            Assert.AreEqual("Some Company", customer.Company);
            Assert.AreEqual("hansolo64@compuserver.com", customer.Email);
            Assert.AreEqual("312.555.1111", customer.Phone);
            Assert.AreEqual("312.555.1112", customer.Fax);
            Assert.AreEqual("www.disney.com", customer.Website);
            Assert.AreEqual(DateTime.Now.Year, customer.CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.UpdatedAt.Year);
        }

        [Test]
        public void Create_CreateCustomerWithCreditCard()
        {
            var createRequest = new CustomerRequest()
            {
                FirstName = "Michael",
                LastName = "Angelo",
                Company = "Some Company",
                Email = "hansolo64@compuserver.com",
                Phone = "312.555.1111",
                Fax = "312.555.1112",
                Website = "www.disney.com",
                CreditCard = new CreditCardRequest()
                {
                    Number = "5105105105105100",
                    ExpirationDate = "05/12",
                    CVV = "123",
                    CardholderName = "Michael Angelo"
                }
            };

            Customer customer = gateway.Customer.Create(createRequest).Target;
            Assert.AreEqual("Michael", customer.FirstName);
            Assert.AreEqual("Angelo", customer.LastName);
            Assert.AreEqual("Some Company", customer.Company);
            Assert.AreEqual("hansolo64@compuserver.com", customer.Email);
            Assert.AreEqual("312.555.1111", customer.Phone);
            Assert.AreEqual("312.555.1112", customer.Fax);
            Assert.AreEqual("www.disney.com", customer.Website);
            Assert.AreEqual(DateTime.Now.Year, customer.CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.UpdatedAt.Year);
            Assert.AreEqual(1, customer.CreditCards.Length);
            Assert.AreEqual("510510", customer.CreditCards[0].Bin);
            Assert.AreEqual("5100", customer.CreditCards[0].LastFour);
            Assert.AreEqual("05", customer.CreditCards[0].ExpirationMonth);
            Assert.AreEqual("2012", customer.CreditCards[0].ExpirationYear);
            Assert.AreEqual("Michael Angelo", customer.CreditCards[0].CardholderName);
            Assert.AreEqual(DateTime.Now.Year, customer.CreditCards[0].CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.CreditCards[0].UpdatedAt.Year);
        }

        [Test]
        public void Create_CreateCustomerWithCreditCardAndBillingAddress()
        {
            var createRequest = new CustomerRequest()
            {
                FirstName = "Michael",
                LastName = "Angelo",
                Company = "Some Company",
                Email = "hansolo64@compuserver.com",
                Phone = "312.555.1111",
                Fax = "312.555.1112",
                Website = "www.disney.com",
                CreditCard = new CreditCardRequest()
                {
                    Number = "5105105105105100",
                    ExpirationDate = "05/12",
                    CVV = "123",
                    CardholderName = "Michael Angelo",
                    BillingAddress = new AddressRequest()
                    {
                        FirstName = "Michael",
                        LastName = "Angelo",
                        Company = "Angelo Co.",
                        StreetAddress = "1 E Main St",
                        ExtendedAddress = "Apt 3",
                        Locality = "Chicago",
                        Region = "IL",
                        PostalCode = "60622",
                        CountryName = "United States of America"
                    }
                }
            };

            Customer customer = gateway.Customer.Create(createRequest).Target;
            Assert.AreEqual("Michael", customer.FirstName);
            Assert.AreEqual("Angelo", customer.LastName);
            Assert.AreEqual("Some Company", customer.Company);
            Assert.AreEqual("hansolo64@compuserver.com", customer.Email);
            Assert.AreEqual("312.555.1111", customer.Phone);
            Assert.AreEqual("312.555.1112", customer.Fax);
            Assert.AreEqual("www.disney.com", customer.Website);
            Assert.AreEqual(DateTime.Now.Year, customer.CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.UpdatedAt.Year);
            Assert.AreEqual(1, customer.CreditCards.Length);
            Assert.AreEqual("510510", customer.CreditCards[0].Bin);
            Assert.AreEqual("5100", customer.CreditCards[0].LastFour);
            Assert.AreEqual("05", customer.CreditCards[0].ExpirationMonth);
            Assert.AreEqual("2012", customer.CreditCards[0].ExpirationYear);
            Assert.AreEqual("Michael Angelo", customer.CreditCards[0].CardholderName);
            Assert.AreEqual(DateTime.Now.Year, customer.CreditCards[0].CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, customer.CreditCards[0].UpdatedAt.Year);
            Assert.AreEqual(customer.Addresses[0].ID, customer.CreditCards[0].BillingAddress.ID);
            Assert.AreEqual("Michael", customer.Addresses[0].FirstName);
            Assert.AreEqual("Angelo", customer.Addresses[0].LastName);
            Assert.AreEqual("Angelo Co.", customer.Addresses[0].Company);
            Assert.AreEqual("1 E Main St", customer.Addresses[0].StreetAddress);
            Assert.AreEqual("Apt 3", customer.Addresses[0].ExtendedAddress);
            Assert.AreEqual("Chicago", customer.Addresses[0].Locality);
            Assert.AreEqual("IL", customer.Addresses[0].Region);
            Assert.AreEqual("60622", customer.Addresses[0].PostalCode);
            Assert.AreEqual("United States of America", customer.Addresses[0].CountryName);
        }

        [Test]
        public void ConfirmTransparentRedirect_CreatesTheCustomer()
        {
            CustomerRequest trParams = new CustomerRequest();

            CustomerRequest request = new CustomerRequest
            {
                FirstName = "John",
                LastName = "Doe"
            };

            String queryString = TestHelper.QueryStringForTR(trParams, request, gateway.Customer.TransparentRedirectURLForCreate());
            Result<Customer> result = gateway.Customer.ConfirmTransparentRedirect(queryString);
            Assert.IsTrue(result.IsSuccess());
            Customer customer = result.Target;
            Assert.AreEqual("John", customer.FirstName);
            Assert.AreEqual("Doe", customer.LastName);
        }

        [Test]
        public void ConfirmTransparentRedirect_CreatesNestedElementsAndCustomFields()
        {
            CustomerRequest trParams = new CustomerRequest();

            CustomerRequest request = new CustomerRequest
            {
                FirstName = "John",
                LastName = "Doe",
                CreditCard = new CreditCardRequest
                {
                    Number = SandboxValues.CreditCardNumber.VISA,
                    CardholderName = "John Doe",
                    ExpirationDate = "05/10"
                },
                CustomFields = new Dictionary<String, String>
                {
                    { "store_me", "a custom value" }
                }
            };

            String queryString = TestHelper.QueryStringForTR(trParams, request, gateway.Customer.TransparentRedirectURLForCreate());
            Result<Customer> result = gateway.Customer.ConfirmTransparentRedirect(queryString);
            Assert.IsTrue(result.IsSuccess());
            Customer customer = result.Target;
            Assert.AreEqual("John", customer.FirstName);
            Assert.AreEqual("Doe", customer.LastName);
            Assert.AreEqual("John Doe", customer.CreditCards[0].CardholderName);
            Assert.AreEqual("a custom value", customer.CustomFields["store-me"]);
        }

        [Test]
        public void ConfirmTransparentRedirect_UpdatesTheCustomer()
        {
            CustomerRequest createRequest = new CustomerRequest
            {
                FirstName = "Jane",
                LastName = "Deer"
            };
            Customer createdCustomer = gateway.Customer.Create(createRequest).Target;

            CustomerRequest trParams = new CustomerRequest
            {
                CustomerID = createdCustomer.ID
            };

            CustomerRequest request = new CustomerRequest
            {
                FirstName = "John",
                LastName = "Doe"
            };

            String queryString = TestHelper.QueryStringForTR(trParams, request, gateway.Customer.TransparentRedirectURLForUpdate());
            Result<Customer> result = gateway.Customer.ConfirmTransparentRedirect(queryString);
            Assert.IsTrue(result.IsSuccess());
            Customer customer = result.Target;
            Assert.AreEqual("John", customer.FirstName);
            Assert.AreEqual("Doe", customer.LastName);
        }

        [Test]
        public void Update_UpdatesCustomerWithNewValues()
        {
            string oldID = Guid.NewGuid().ToString();
            string newID = Guid.NewGuid().ToString();
            var createRequest = new CustomerRequest()
            {
                ID = oldID,
                FirstName = "Old First",
                LastName = "Old Last",
                Company = "Old Company",
                Email = "old@example.com",
                Phone = "312.555.1111 xOld",
                Fax = "312.555.1112 xOld",
                Website = "old.example.com"
            };

            var originalCustomer = gateway.Customer.Create(createRequest);

            var updateRequest = new CustomerRequest()
            {
                ID = newID,
                FirstName = "Michael",
                LastName = "Angelo",
                Company = "Some Company",
                Email = "hansolo64@compuserver.com",
                Phone = "312.555.1111",
                Fax = "312.555.1112",
                Website = "www.disney.com"
            };

            Customer updatedCustomer = gateway.Customer.Update(oldID, updateRequest).Target;
            Assert.AreEqual(newID, updatedCustomer.ID);
            Assert.AreEqual("Michael", updatedCustomer.FirstName);
            Assert.AreEqual("Angelo", updatedCustomer.LastName);
            Assert.AreEqual("Some Company", updatedCustomer.Company);
            Assert.AreEqual("hansolo64@compuserver.com", updatedCustomer.Email);
            Assert.AreEqual("312.555.1111", updatedCustomer.Phone);
            Assert.AreEqual("312.555.1112", updatedCustomer.Fax);
            Assert.AreEqual("www.disney.com", updatedCustomer.Website);
            Assert.AreEqual(DateTime.Now.Year, updatedCustomer.CreatedAt.Year);
            Assert.AreEqual(DateTime.Now.Year, updatedCustomer.UpdatedAt.Year);
        }

        [Test]
        public void Delete_DeletesTheCustomer()
        {
            String id = Guid.NewGuid().ToString();
            gateway.Customer.Create(new CustomerRequest() { ID = id });
            Assert.AreEqual(id, gateway.Customer.Find(id).Target.ID);
            gateway.Customer.Delete(id);
            Assert.Throws<NotFoundError>(() => gateway.Customer.Find(id));
        }
    }
}
