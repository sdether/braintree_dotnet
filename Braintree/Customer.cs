﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Braintree
{
    public class Customer
    {   
        public String ID { get; protected set; }
        public String FirstName { get; protected set; }
        public String LastName { get; protected set; }
        public String Company { get; protected set; }
        public String Email { get; protected set; }
        public String Phone { get; protected set; }
        public String Fax { get; protected set; }
        public String Website { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public CreditCard[] CreditCards { get; protected set; }
        public Address[] Addresses { get; protected set; }
        public Dictionary<String, String> CustomFields { get; protected set; }

        internal Customer(NodeWrapper node)
        {
            if (node == null) return;

            ID = node.GetString("id");
            FirstName = node.GetString("first-name");
            LastName = node.GetString("last-name");
            Company = node.GetString("company");
            Email = node.GetString("email");
            Phone = node.GetString("phone");
            Fax = node.GetString("fax");
            Website = node.GetString("website");

            var createdAt = node.GetDateTime("created-at");
            if (createdAt != null) CreatedAt = (DateTime) createdAt;

            var updatedAt = node.GetDateTime("updated-at");
            if (updatedAt != null) UpdatedAt = (DateTime) updatedAt;

            var creditCardXmlNodes = node.GetArray("credit-cards/credit-card");
            CreditCards = new CreditCard[creditCardXmlNodes.Count];
            for (int i = 0; i < creditCardXmlNodes.Count; i++)
            {
                CreditCards[i] = new CreditCard(creditCardXmlNodes[i]);
            }

            var addressXmlNodes = node.GetArray("addresses/address");
            Addresses = new Address[addressXmlNodes.Count];
            for (int i = 0; i < addressXmlNodes.Count; i++)
            {
                Addresses[i] = new Address(addressXmlNodes[i]);
            }

            CustomFields = node.GetDictionary("custom-fields");
        }
    }
}
