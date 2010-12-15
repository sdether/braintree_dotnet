namespace Braintree.Testing {
    public class MockResult<T> : Result<T> where T : class {

        public MockResult(T target) {
            Target = target;
        }

        public MockResult<T> WithTransaction(MockTransaction transaction) {
            return this;
        }
    }
}