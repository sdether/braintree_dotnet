using System;
using System.Reflection;

namespace Braintree.Testing {
    public class InvocationTarget {
        public MethodInfo Method;
        public int ExpectedCalls;
        public Func<object[], object> Returns;
        public Func<object[], int> Validator;

        public int ActualCalls { get; private set; }

        public int Match(object[] args) {
            return Validator == null ? 1 : (Validator(args) + 1);
        }

        public object Invoke(object[] args) {
            ActualCalls++;
            return Returns(args);
        }
    }
}