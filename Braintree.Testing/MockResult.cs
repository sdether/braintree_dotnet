namespace Braintree.Testing {
    internal class MockResult<T> : Result<T> where T : class {

        public MockResult(T target) {
            Target = target;
        }
    }
}