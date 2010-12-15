namespace Braintree.Testing {
    public class InvocationVerification {
        public readonly bool IsSuccessful;
        public readonly string FailureMessage;

        public InvocationVerification() {
            IsSuccessful = true;
        }

        public InvocationVerification(string failureMessage, params object[] parameters) {
            IsSuccessful = false;
            if(parameters != null && parameters.Length > 0) {
                FailureMessage = string.Format(failureMessage, parameters);
            } else {
                FailureMessage = failureMessage;
            }
        }
    }
}