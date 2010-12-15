using System;
using System.Linq;

namespace Braintree.Testing {

    // TODO: need to wrap all those arg casts and throw a proper exception on bad arg cast
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
            _target.ExpectationType = ExpectationType.Exactly;
            return this;
        }

        public InvocationSetup ExpectAtLeast(int times) {
            _target.ExpectedCalls = times;
            _target.ExpectationType = ExpectationType.AtLeast;
            return this;
        }

        public InvocationSetup ExpectAtMost(int times) {
            _target.ExpectedCalls = times;
            _target.ExpectationType = ExpectationType.AtMost;
            return this;
        }

        public MockGatewayBuilder ReturnsVoid() {
            return Complete();
        }

        public MockGatewayBuilder Throws(Exception e) {
            _target.Returns = (object[] args) => { throw e; };
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

        public MockGatewayBuilder ReturnsCustomerResult() {
            return ReturnsCustomerResult(r => r.ToCustomer());
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

        public InvocationSetup<T> ValidateArguments<T>(Func<T, bool> argsValidator) {
            _target.Validator = (object[] args) => {
                var arg1 = (T)args[0];
                return argsValidator(arg1) ? 1 : 0;
            };
            return Setup<T>();
        }

        public InvocationSetup<T> ValidateArguments<T>(Func<T, int> argsValidator) {
            _target.Validator = (object[] args) => {
                var arg1 = (T)args[0];
                return argsValidator(arg1);
            };
            return Setup<T>();
        }

        public InvocationSetup<T1, T2> ValidateArguments<T1, T2>(Func<T1, T2, bool> argsValidator) {
            _target.Validator = (object[] args) => {
                var arg1 = (T1)args[0];
                var arg2 = (T2)args[1];
                return argsValidator(arg1, arg2) ? 1 : 0;
            };
            return Setup<T1, T2>();
        }

        public InvocationSetup<T1, T2> ValidateArguments<T1, T2>(Func<T1, T2, int> argsValidator) {
            _target.Validator = (object[] args) => {
                var arg1 = (T1)args[0];
                var arg2 = (T2)args[1];
                return argsValidator(arg1, arg2);
            };
            return Setup<T1, T2>();
        }

        public InvocationSetup<T1, T2, T3> ValidateArguments<T1, T2, T3>(Func<T1, T2, T3, bool> argsValidator) {
            _target.Validator = (object[] args) => {
                var arg1 = (T1)args[0];
                var arg2 = (T2)args[1];
                var arg3 = (T3)args[2];
                return argsValidator(arg1, arg2, arg3) ? 1 : 0;
            };
            return Setup<T1, T2, T3>();
        }

        public InvocationSetup<T1, T2, T3> ValidateArguments<T1, T2, T3>(Func<T1, T2, T3, int> argsValidator) {
            _target.Validator = (object[] args) => {
                var arg1 = (T1)args[0];
                var arg2 = (T2)args[1];
                var arg3 = (T3)args[2];
                return argsValidator(arg1, arg2, arg3);
            };
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

        public new InvocationSetup<T> ExpectNone() {
            return ExpectMany(0);
        }

        public new InvocationSetup<T> ExpectOnce() {
            return ExpectMany(1);
        }

        public new InvocationSetup<T> ExpectMany(int times) {
            base.ExpectMany(times);
            return this;
        }

        public new InvocationSetup<T> ExpectAtLeast(int times) {
            base.ExpectAtLeast(times);
            return this;
        }

        public new InvocationSetup<T> ExpectAtMost(int times) {
            base.ExpectAtMost(times);
            return this;
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

        public new InvocationSetup<T1, T2> ExpectNone() {
            return ExpectMany(0);
        }

        public new InvocationSetup<T1, T2> ExpectOnce() {
            return ExpectMany(1);
        }

        public new InvocationSetup<T1, T2> ExpectMany(int times) {
            base.ExpectMany(times);
            return this;
        }

        public new InvocationSetup<T1, T2> ExpectAtLeast(int times) {
            base.ExpectAtLeast(times);
            return this;
        }

        public new InvocationSetup<T1, T2> ExpectAtMost(int times) {
            base.ExpectAtMost(times);
            return this;
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

        public new InvocationSetup<T1, T2, T3> ExpectNone() {
            return ExpectMany(0);
        }

        public new InvocationSetup<T1, T2, T3> ExpectOnce() {
            return ExpectMany(1);
        }

        public new InvocationSetup<T1, T2, T3> ExpectMany(int times) {
            base.ExpectMany(times);
            return this;
        }

        public new InvocationSetup<T1, T2, T3> ExpectAtLeast(int times) {
            base.ExpectAtLeast(times);
            return this;
        }

        public new InvocationSetup<T1, T2, T3> ExpectAtMost(int times) {
            base.ExpectAtMost(times);
            return this;
        }
    }
}