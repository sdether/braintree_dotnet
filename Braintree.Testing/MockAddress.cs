using System;

namespace Braintree.Testing {
    public class MockAddress : Address {
        
         private static int _id = 0;

        public static MockAddress Create() {
            return Create((_id++).ToString());
        }

       public static MockAddress Create(string id) {
            return new MockAddress() { Id = id };
        }

       public static MockAddress FromRequest(string customerId, AddressRequest request) {
           return new MockAddress() {
               Company = request.Company,
               CountryCodeAlpha2 = request.CountryCodeAlpha2,
               CountryCodeAlpha3 = request.CountryCodeAlpha3,
               CountryCodeNumeric = request.CountryCodeNumeric,
               CountryName = request.CountryName,
               ExtendedAddress = request.ExtendedAddress,
               CustomerId = customerId,
               FirstName = request.FirstName,
               LastName = request.LastName,
               Id = (_id++).ToString(),
               Locality = request.Locality,
               StreetAddress = request.StreetAddress,
               Region = request.Region,
               PostalCode = request.PostalCode
           };
       }

       public static MockAddress FromRequest(string customerId, CreditCardAddressRequest request) {
           return new MockAddress() {
               Company = request.Company,
               CountryCodeAlpha2 = request.CountryCodeAlpha2,
               CountryCodeAlpha3 = request.CountryCodeAlpha3,
               CountryCodeNumeric = request.CountryCodeNumeric,
               CountryName = request.CountryName,
               ExtendedAddress = request.ExtendedAddress,
               CustomerId = customerId,
               FirstName = request.FirstName,
               LastName = request.LastName,
               Id = (_id++).ToString(),
               Locality = request.Locality,
               StreetAddress = request.StreetAddress,
               Region = request.Region,
               PostalCode = request.PostalCode
           };
       }

        private MockAddress() { }

        public MockAddress WithCustomerId(string customerId) {
            return this;
        }
        public MockAddress WithFirstName( string firstName) {
            return this;
        }
        public MockAddress WithLastName( string lastName) {
            return this;
        }
        public MockAddress WithCompany( string company) {
            return this;
        }
        public MockAddress WithStreetAddress( string streetAddress) {
            return this;
        }
        public MockAddress WithExtendedAddress( string extendedAddress) {
            return this;
        }
        public MockAddress WithLocality( string locality) {
            return this;
        }
        public MockAddress WithRegion( string region) {
            return this;
        }
        public MockAddress WithPostalCode( string postalCode) {
            return this;
        }
        public MockAddress WithCountryCodeAlpha2( string countryCodeAlpha2) {
            return this;
        }
        public MockAddress WithCountryCodeAlpha3( string countryCodeAlpha3) {
            return this;
        }
        public MockAddress WithCountryCodeNumeric( string countryCodeNumeric) {
            return this;
        }
        public MockAddress WithCountryName( string countryName) {
            return this;
        }
        public MockAddress WithCreatedAt( DateTime? createdAt) {
            return this;
        }
        public MockAddress WithUpdatedAt( DateTime? updatedAt ) {
            return this;
        }
    }
}