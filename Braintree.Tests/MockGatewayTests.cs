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
                .Setup(g => g.Customer.Create(Arg.CustomerRequest)).ReturnsCustomerResult()
                .Build();
            var customerRequest = gateway.Customer.Create(new CustomerRequest() { FirstName = "bob" });
            var customer = customerRequest.Target;
            Assert.AreEqual("bob", customer.FirstName);
        }

        [Test]
        public void Setup_with_validation_matches_before_setup_without() {
            var gateway = MockGateway.Configure()
                .Setup(g => g.Customer.Update(Arg.String, Arg.CustomerRequest))
                    .ReturnsCustomerResult(r => r.ToCustomer((m) => m.WithId("novalidation")))
                .Setup(g => g.Customer.Update(Arg.String, Arg.CustomerRequest))
                    .ValidateArguments<string, CustomerRequest>((id, r) => {
                        return id == "789";
                    })
                    .ReturnsCustomerResult(r => r.ToCustomer((m) => m.WithId("badvaldidation")))
                .Setup(g => g.Customer.Update(Arg.String, Arg.CustomerRequest))
                    .ValidateArguments<string, CustomerRequest>((id, r) => {
                        return id == "1234" ? 2 : 0;
                    })
                    .ReturnsCustomerResult(r => r.ToCustomer((m) => m.WithId("validation")))
                .Build();
            var customerRequest = gateway.Customer.Update("1234",new CustomerRequest() { FirstName = "bob" });
            var customer = customerRequest.Target;
            Assert.AreEqual("bob", customer.FirstName);
            Assert.AreEqual("validation", customer.Id);
        }
    }
}
