using System;
using System.Reflection;

namespace Braintree.Testing {
    public class InvocationTarget {
        public MethodInfo Method;
        public int ExpectedCalls;
        public ExpectationType ExpectationType;
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

        public InvocationVerification Verify() {
            switch(ExpectationType) {
            case ExpectationType.Exactly:
                if(ExpectedCalls != ActualCalls) {
                    return new InvocationVerification("{0} expected exactly {1} calls, received {2}",Method,ExpectedCalls,ActualCalls);
                }
                break;
            case ExpectationType.AtLeast:
                if(ExpectedCalls > ActualCalls) {
                    return new InvocationVerification("{0} expected at least {1} calls, received {2}", Method, ExpectedCalls, ActualCalls);
                }
                break;
            case ExpectationType.AtMost:
                if(ExpectedCalls <= ActualCalls) {
                    return new InvocationVerification("{0} expected at least {1} calls, received {2}", Method, ExpectedCalls, ActualCalls);
                }
                break;
            }
            return new InvocationVerification();
        }
    }
}