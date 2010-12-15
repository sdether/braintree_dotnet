namespace Braintree.Testing {
    public class MockAddressGateway : AddressGateway {
        private readonly ICallbackProvider _callbackProvider;

        public MockAddressGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }

        public override Result<Address> Create(string customerId, AddressRequest request) {
            return _callbackProvider.Invoke<Result<Address>>(customerId, request);
        }
        public override void Delete(string customerId, string id) {
            _callbackProvider.Invoke(customerId, id);
        }
        public override Address Find(string customerId, string id) {
            return _callbackProvider.Invoke<Address>(customerId, id);
        }
        public override Result<Address> Update(string customerId, string id, AddressRequest request) {
            return _callbackProvider.Invoke<Result<Address>>(customerId, id, request);
        }
    }
}