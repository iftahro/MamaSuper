using System;
using System.Linq;
using MamaSuper.Common.Interfaces;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints all customers in line
    /// </summary>
    public class CustomersLinePrinter : IMenuOption
    {
        private readonly ICustomersLineService _customersLineService;

        public CustomersLinePrinter(ICustomersLineService customersLineService)
        {
            _customersLineService = customersLineService;
        }

        public string Description { get; } = "Print all customers in line";

        public void Action()
        {
            if (_customersLineService.CountLineCustomers() == 0)
            {
                Console.WriteLine("There are no customers in line\n");
                return;
            }

            Console.WriteLine("Current customers in line:");
            _customersLineService.GetLineCustomers().ToList().ForEach(Console.WriteLine);
        }
    }
}