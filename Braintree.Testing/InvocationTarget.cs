using System;
using System.Reflection;

namespace Braintree.Testing {
    public class InvocationTarget {
        public MethodInfo Method;
        public int ExpectedCalls;
        public Func<object[], object> Returns;
        public Func<object[], bool> Validator;

        public int ActualCalls { get; private set; }

        public bool Match(object[] args) {
            return Validator == null || Validator(args);
        }

        public object Invoke(object[] args) {
            ActualCalls++;
            return Returns(args);
        }
    }
}