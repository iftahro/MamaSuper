using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Adds a new customer to the supermarket line 
    /// </summary>
    public class CustomersLineAdder : IMenuOption
    {
        private readonly ILineService<Customer> _customersLineService;

        public CustomersLineAdder(ILineService<Customer> customersLineService)
        {
            _customersLineService = customersLineService;
        }

        public string Description { get; } = "Add new customer to the line";

        public void Action()
        {
            string customerName = ConsoleUtils.GetInputAfterOutput("Enter customer name:");

            string bodyTempInput = ConsoleUtils.GetInputAfterOutput($"Enter {customerName}'s body temp (c° degree):");
            if (!bodyTempInput.TryParseToInt(out int bodyTemperature)) return;

            string hasMaskInput = ConsoleUtils.GetInputAfterOutput($"Does {customerName} wear mask? (true/false)");
            if (!hasMaskInput.TryParseToBool(out bool maskOn)) return;

            string shouldIsolateInput = ConsoleUtils.GetInputAfterOutput($"Does {customerName} should be isolated? (true/false)");
            if (!shouldIsolateInput.TryParseToBool(out bool shouldIsolate)) return;

            var customer = new Customer(customerName, bodyTemperature, maskOn, shouldIsolate);
            if (!_customersLineService.TryAddItem(customer, out string failingMessage))
            {
                Console.WriteLine($"\nFailed adding customer to line. Failing reason:\n{failingMessage}\n");
                return;
            }

            Console.WriteLine($"Added customer '{customer}' to the line!\n");
        }
    }
}