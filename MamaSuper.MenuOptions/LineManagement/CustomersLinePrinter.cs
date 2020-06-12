using System;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints all customers in line
    /// </summary>
    public class CustomersLinePrinter : IMenuOption
    {
        private readonly ILineService<Customer> _customersLineService;

        public CustomersLinePrinter(ILineService<Customer> customersLineService)
        {
            _customersLineService = customersLineService;
        }

        public string Description { get; } = "Print all customers in line";

        public void Action()
        {
            if (_customersLineService.CountLineItems() == 0)
            {
                Console.WriteLine("There are no customers in line");
                return;
            }

            Console.WriteLine("Current customers in line:");
            _customersLineService.GetLineItems().ToList().ForEach(Console.WriteLine);
        }
    }
}