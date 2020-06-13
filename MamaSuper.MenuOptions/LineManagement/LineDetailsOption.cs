using System;
using System.Linq;
using MamaSuper.Common.Interfaces;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints the line details (current customers in line)
    /// </summary>
    public class LineDetailsOption : IMenuOption
    {
        private readonly ICustomersLineService _customersLineService;

        public LineDetailsOption(ICustomersLineService customersLineService)
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