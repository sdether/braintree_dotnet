#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Xml;

namespace Braintree
{
    /// <summary>
    /// Provides operations for creating, finding, updating, and deleting customers in the vault
    /// </summary>
    public class CustomerGateway
    {
        private BraintreeService Service;

        internal CustomerGateway(BraintreeService service)
        {
            Service = service;
        }

        public virtual Customer Find(String Id)
        {
            XmlNode customerXML = Service.Get("/customers/" + Id);

            return new Customer(new NodeWrapper(customerXML), Service);
        }

        public virtual Result<Customer> Create(CustomerRequest request)
        {
            XmlNode customerXML = Service.Post("/customers", request);

            return new Result<Customer>(new NodeWrapper(customerXML), Service);
        }

        public virtual void Delete(String Id)
        {
            Service.Delete("/customers/" + Id);
        }

        public virtual Result<Customer> Update(String Id, CustomerRequest request)
        {
            XmlNode customerXML = Service.Put("/customers/" + Id, request);

            return new Result<Customer>(new NodeWrapper(customerXML), Service);
        }

        [Obsolete("Use gateway.TransparentRedirect.Confirm()")]
        public virtual Result<Customer> ConfirmTransparentRedirect(String queryString)
        {
            TransparentRedirectRequest trRequest = new TransparentRedirectRequest(queryString, Service);
            XmlNode node = Service.Post("/customers/all/confirm_transparent_redirect_request", trRequest);

            return new Result<Customer>(new NodeWrapper(node), Service);
        }

        [Obsolete("Use gateway.TransparentRedirect.Url")]
        public virtual String TransparentRedirectURLForCreate()
        {
            return Service.BaseMerchantURL() + "/customers/all/create_via_transparent_redirect_request";
        }

        [Obsolete("Use gateway.TransparentRedirect.Url")]
        public virtual String TransparentRedirectURLForUpdate()
        {
            return Service.BaseMerchantURL() + "/customers/all/update_via_transparent_redirect_request";
        }

        public virtual ResourceCollection<Customer> All()
        {
            NodeWrapper response = new NodeWrapper(Service.Post("/customers/advanced_search_ids"));

            return new ResourceCollection<Customer>(response, delegate(String[] ids) {
                return FetchCustomers(ids);
            });
        }

        private List<Customer> FetchCustomers(String[] ids)
        {
            IdsSearchRequest query = new IdsSearchRequest().
                Ids.IncludedIn(ids);

            NodeWrapper response = new NodeWrapper(Service.Post("/customers/advanced_search", query));

            List<Customer> customers = new List<Customer>();
            foreach (NodeWrapper node in response.GetList("customer"))
            {
                customers.Add(new Customer(node, Service));
            }
            return customers;
        }
    }
}
