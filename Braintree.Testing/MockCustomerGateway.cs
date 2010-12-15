using System;
using System.Diagnostics;

namespace Braintree.Testing {
#pragma warning disable 672
    public class MockCustomerGateway : CustomerGateway {
        private readonly ICallbackProvider _callbackProvider;

        internal MockCustomerGateway(ICallbackProvider callbackProvider) {
            _callbackProvider = callbackProvider;
        }
        public override ResourceCollection<Customer> All() {
            return _callbackProvider.Invoke<ResourceCollection<Customer>>();
        }
        public override Result<Customer> ConfirmTransparentRedirect(string queryString) {
            throw new NotImplementedException("The mock gateway does implement this method");
        }
        public override Result<Customer> Create(CustomerRequest request) {
            return _callbackProvider.Invoke<Result<Customer>>(request);
        }
        public override void Delete(string Id) {
            _callbackProvider.Invoke(Id);
        }
        public override Customer Find(string Id) {
            return _callbackProvider.Invoke<Customer>(Id);
        }
        public override string TransparentRedirectURLForCreate() {
            throw new NotImplementedException("The mock gateway does implement this method");
        }
        public override string TransparentRedirectURLForUpdate() {
            throw new NotImplementedException("The mock gateway does implement this method");
        }
        public override Result<Customer> Update(string Id, CustomerRequest request) {
            return _callbackProvider.Invoke<Result<Customer>>(Id, request);
        }
    }
#pragma warning restore 672
}