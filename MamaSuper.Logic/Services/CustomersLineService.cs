using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="ICustomersLineService"/>
    /// </summary>
    public class CustomersLineService : ICustomersLineService
    {
        private readonly Line<Customer> _customersLine;

        public CustomersLineService(Line<Customer> customersLine)
        {
            _customersLine = customersLine;
        }

        public event EventHandler<Customer> CustomerMovedOut;

        public bool TryAddCustomer(Customer customer, out string failingMessage)
        {
            if (!customer.IsPermittedToEnter(out failingMessage))
                return false;

            _customersLine.AddLineItem(customer);
            return true;
        }

        public IEnumerable<Customer> GetLineCustomers()
        {
            return _customersLine.GetLineItems();
        }

        public IEnumerable<Customer> MoveOutCustomers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Customer customer = _customersLine.RemoveLineItem();
                CustomerMovedOut?.Invoke(this, customer);
                yield return customer;
            }
        }

        public int CountLineCustomers()
        {
            return _customersLine.CountLineItems();
        }
    }
}
