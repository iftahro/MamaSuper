using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints all customers in line
    /// </summary>
    public class CustomersLinePrinter : IMenuOption
    {
        public string Description { get; }

        private readonly ILineService<Customer> _customersLineService;

        public CustomersLinePrinter(string description, ILineService<Customer> customersLineService)
        {
            Description = description;
            _customersLineService = customersLineService;
        }

        public void Action()
        {
            IList<Customer> currentLineCostumers = _customersLineService.GetLineItems();
            if (currentLineCostumers.Count == 0)
            {
                Console.WriteLine("There are no customers in line");
                return;
            }

            Console.WriteLine("Current customers in line:");
            foreach (Customer costumer in currentLineCostumers)
            {
                Console.WriteLine(costumer);
            }
        }
    }
}