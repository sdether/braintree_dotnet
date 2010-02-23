﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Braintree
{
    public class Result<T> where T : class
    {
        public CreditCardVerification CreditCardVerification { get; protected set; }
        public ValidationErrors Errors { get; protected set; }
        public Dictionary<String, String> Parameters { get; protected set; }
        public T Target { get; protected set; }

        public Result(NodeWrapper node)
        {
            if (node.IsSuccess())
            {
                Target = newInstanceFromResponse(node);
            }
            else
            {
                Errors = new ValidationErrors(node);
                CreditCardVerification = new CreditCardVerification(node.GetNode("//verification"));
                Parameters = node.GetNode("//params").GetFormParameters();
            }
        }

        public Boolean IsSuccess()
        {
            return Errors == null;
        }

        private T newInstanceFromResponse(NodeWrapper node)
        {
            if (typeof(T) == typeof(Address))
            {
                return new Address(node) as T;
            }
            else if (typeof(T) == typeof(CreditCard))
            {
                return new CreditCard(node) as T;
            }
            else if (typeof(T) == typeof(Customer))
            {
                return new Customer(node) as T;
            }
            else if (typeof(T) == typeof(Transaction))
            {
                return new Transaction(node) as T;
            }

            throw new Exception("Unknown T: " + typeof(T).ToString());
        }
    }
}
