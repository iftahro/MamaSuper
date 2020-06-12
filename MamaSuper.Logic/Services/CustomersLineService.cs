using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="ILineService{T}"/>
    /// </summary>
    public class CustomersLineService : ILineService<Customer>
    {
        private readonly Line<Customer> _customersLine;

        public CustomersLineService(Line<Customer> customersLine)
        {
            _customersLine = customersLine;
        }

        public bool TryAddItemToLine(Customer customer, out string failingMessage)
        {
            if (!customer.IsPermittedToEnter(out failingMessage))
                return false;

            _customersLine.AddLineItem(customer);
            return true;
        }

        public IList<Customer> GetLineItems()
        {
            return _customersLine.GetLineItems().ToList();
        }

        public IEnumerable<Customer> MoveItemsFromLine(int count)
        {
            for (int i = 0; i < _customersLine.CountLineItems(); i++)
            {
                Customer customer = _customersLine.RemoveLineItem();
                yield return customer;
            }
        }
    }
}
