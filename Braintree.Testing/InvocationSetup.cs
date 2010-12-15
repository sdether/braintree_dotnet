using System;
using System.Linq;

namespace Braintree.Testing {
    public class InvocationSetup {
        protected readonly InvocationTarget _target;
        protected readonly Func<InvocationTarget, MockGatewayBuilder> _completion;

        internal InvocationSetup(InvocationTarget target, Func<InvocationTarget, MockGatewayBuilder> completion) {
            _target = target;
            _completion = completion;
        }

        public InvocationSetup ExpectNone() {
            return ExpectMany(0);
        }

        public InvocationSetup ExpectOnce() {
            return ExpectMany(1);
        }

        public InvocationSetup ExpectMany(int times) {
            _target.ExpectedCalls = times;
            return this;
        }

        public MockGatewayBuilder ReturnsVoid() {
            return Complete();
        }

        public MockGatewayBuilder ReturnsCustomerResult(Func<CustomerRequest, Result<Customer>> request) {
            _target.Returns = (object[] args) => {
                var customerRequest = args.Where(x => typeof(CustomerRequest).IsAssignableFrom(x.GetType())).FirstOrDefault() as CustomerRequest;
                if(customerRequest == null) {
                    throw new InvalidOperationException("Invocation arguments do not contain one of type CustomerRequest");
                }
                return request(customerRequest);
            };
            return Complete();
        }

        public MockGatewayBuilder ReturnsDefault() {
            return Complete();
        }

        public MockGatewayBuilder Returns<T, TResult>(Func<T, TResult> returnCallback) {
            return Setup<T>().Returns(returnCallback);
        }

        public MockGatewayBuilder Returns<T1, T2, TResult>(Func<T1, T2, TResult> returnCallback) {
            return Setup<T1, T2>().Returns(returnCallback);
        }

        public MockGatewayBuilder Returns<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> returnCallback) {
            return Setup<T1, T2, T3>().Returns(returnCallback);
        }

        public InvocationSetup<T> ValidateArguments<T>(Func<T, bool> args) {
            return Setup<T>();
        }

        public InvocationSetup<T1, T2> ValidateArguments<T1, T2>(Func<T1, T2, bool> args) {
            return Setup<T1, T2>();
        }

        public InvocationSetup<T1, T2, T3> ValidateArguments<T1, T2, T3>(Func<T1, T2, T3, bool> args) {
            return Setup<T1, T2, T3>();
        }

        private InvocationSetup<T> Setup<T>() {
            return new InvocationSetup<T>(_target, _completion);
        }

        private InvocationSetup<T1, T2> Setup<T1, T2>() {
            return new InvocationSetup<T1, T2>(_target, _completion);
        }

        private InvocationSetup<T1, T2, T3> Setup<T1, T2, T3>() {
            return new InvocationSetup<T1, T2, T3>(_target, _completion);
        }

        protected MockGatewayBuilder Complete() {
            return _completion(_target);
        }

    }

    public class InvocationSetup<T> : InvocationSetup {

        public InvocationSetup(InvocationTarget target, Func<InvocationTarget, MockGatewayBuilder> completion) : base(target, completion) { }

        public MockGatewayBuilder Returns<TResult>(Func<T, TResult> returnCallback) {
            _target.Returns = (object[] args) => {
                var arg1 = (T)args[0];
                return returnCallback(arg1);
            };
            return Complete();
        }
    }

    public class InvocationSetup<T1, T2> : InvocationSetup {

        public InvocationSetup(InvocationTarget target, Func<InvocationTarget, MockGatewayBuilder> completion) : base(target, completion) { }

        public MockGatewayBuilder Returns<TResult>(Func<T1, T2, TResult> returnCallback) {
            _target.Returns = (object[] args) => {
                var arg1 = (T1)args[0];
                var arg2 = (T2)args[1];
                return returnCallback(arg1, arg2);
            };
            return Complete();
        }
    }

    public class InvocationSetup<T1, T2, T3> : InvocationSetup {

        public InvocationSetup(InvocationTarget target, Func<InvocationTarget, MockGatewayBuilder> completion) : base(target, completion) { }

        public MockGatewayBuilder Returns<TResult>(Func<T1, T2, T3, TResult> returnCallback) {
            _target.Returns = (object[] args) => {
                var arg1 = (T1)args[0];
                var arg2 = (T2)args[1];
                var arg3 = (T3)args[2];
                return returnCallback(arg1, arg2, arg3);
            };
            return Complete();
        }
    }
}