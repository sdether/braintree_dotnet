namespace Braintree.Testing
{
    public class Prototyping {
        public static void Test()
        {
            var gateway = MockGateway.Configure()
                .Setup(g => g.Customer.Delete(Arg.String)).ReturnsVoid()
                .Setup(g => g.Customer.Create(Arg.CustomerRequest)).ReturnsCustomerResult(r => r.ToCustomer())
                .Setup(g => g.Customer.Update(Arg.String, Arg.CustomerRequest))
                    .ValidateArguments<string, CustomerRequest>((id, r) => id == "abc")
                    .ExpectOnce()
                    .ReturnsDefault()
                .Build();
            var customerRequest = gateway.Customer.Create(new CustomerRequest() { FirstName = "bob" });
            var customer = customerRequest.Target;
        }
    }
}