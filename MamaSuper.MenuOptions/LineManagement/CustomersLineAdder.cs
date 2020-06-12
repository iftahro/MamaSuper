using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
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
            if (!handleNumericInput(bodyTempInput, out int bodyTemperature)) return;

            string hasMaskInput = ConsoleUtils.GetInputAfterOutput($"Does {customerName} wear mask? (true/false)");
            if (!handleBooleanInput(hasMaskInput, out bool maskOn)) return;

            string shouldIsolateInput = ConsoleUtils.GetInputAfterOutput($"Does {customerName} should be isolated? (true/false)");
            if (!handleBooleanInput(shouldIsolateInput, out bool shouldIsolate)) return;

            var customer = new Customer(customerName, bodyTemperature, maskOn, shouldIsolate);
            if (!_customersLineService.TryAddItem(customer, out string failingMessage))
            {
                Console.WriteLine($"\nFailed adding customer to line. Failing reason:\n{failingMessage}\n");
                return;
            }

            Console.WriteLine($"Added customer '{customer}' to the line!\n");
        }

        private bool handleNumericInput(string numericInput, out int bodyTemperature)
        {
            if (!int.TryParse(numericInput, out bodyTemperature))
            {
                Console.WriteLine($"'{numericInput}' is not a valid number!\nTry again..\n");
                return false;
            }

            return true;
        }

        private bool handleBooleanInput(string booleanInput, out bool answer)
        {
            if (!bool.TryParse(booleanInput, out answer))
            {
                Console.WriteLine($"'{booleanInput}' is not true/false!\nTry again..\n");
                return false;
            }

            return true;
        }
    }
}