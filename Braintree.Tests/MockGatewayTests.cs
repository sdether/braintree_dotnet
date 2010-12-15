using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Braintree.Testing;
using NUnit.Framework;

namespace Braintree.Tests {
    
    [TestFixture]
    public class MockGatewayTests {

        [Test]
        public void Can_set_up_customer_create() {
            var gateway = MockGateway.Configure()
                .Setup(g => g.Customer.Create(Arg.CustomerRequest)).ReturnsCustomerResult(r => r.ToCustomer())
                .Build();
            var customerRequest = gateway.Customer.Create(new CustomerRequest() { FirstName = "bob" });
            var customer = customerRequest.Target;
            Assert.AreEqual("bob",customer.FirstName);
        }
    }
}
