using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Braintree.Testing {
    public class MockGatewayBuilder {
        private readonly Interceptor _interceptor;

        public MockGatewayBuilder() {
            _interceptor = new Interceptor();
        }

        public InvocationSetup Setup(Expression<Action<BraintreeGateway>> expression) {
            var target = new InvocationTarget { Method = GetTargetMethodFromExpression(expression) };
            return new InvocationSetup(target,
                t => {
                    _interceptor.AddInvocationTarget(t);
                    return this;
                }
            );
        }

        private MethodInfo GetTargetMethodFromExpression(Expression<Action<BraintreeGateway>> expression) {
            var body = expression.Body;
            var callExpression = body as MethodCallExpression;
            if(callExpression == null) {
                throw new InvalidOperationException("Cannot determine gateway method called from expression: " + expression.Body);
            }
            return callExpression.Method;
        }

        public MockGateway Build() {
            return new MockGateway(_interceptor);
        }
    }
}