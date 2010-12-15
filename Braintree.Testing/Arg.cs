namespace Braintree.Testing {
    public class Arg {
        public static T Type<T>() {
            return default(T);
        }
        public static readonly string String;
        public static readonly CustomerRequest CustomerRequest;
    }
}