using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Braintree.Testing {
    public class MockGateway : BraintreeGateway, ICallbackProvider {

        public static MockGateway Create() {
            return new MockGateway();
        }

        private MockGateway() {}

        public override CustomerGateway Customer {
            get {
                return new MockCustomerGateway(this);
            }
        }

        public MockGatewaySetup Setup(Expression<Action<BraintreeGateway>> method) {
            return new MockGatewaySetup(this);
        }

        public MockGateway Setup<TReturn>(Expression<Func<BraintreeGateway, TReturn>> method, Expression<Action<TReturn>> returns) {
            return this;
        }

        public MockGateway Setup<TReturn>(Expression<Func<BraintreeGateway, TReturn>> method, Expression<Func<TReturn>> returns) {
            return this;
        }

        public void Verify() { }
    }


    public class Prototyping {
        public static void Test() {
            MockGateway.Create()
                .Setup(g => g.Customer.All()).ReturnsVoid()
                .Setup(g => g.Customer.Create(Any.CustomerRequest)).ReturnsCustomerResult(r => r.ToCustomer())
                .Setup(g => g.Customer.Update(Any.String, Any.CustomerRequest))
                    .ValidateArguments<string, CustomerRequest>((id, r) => id == "abc")
                    .ExpectOnce()
                    .ReturnsDefault();
        }
    }


}
