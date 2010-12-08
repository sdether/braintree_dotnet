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

    }
}