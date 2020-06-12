using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Adds a new customer to the supermarket line 
    /// </summary>
    public class CustomersLineAdder : IMenuOption
    {
        public string Description { get; }

        private readonly ILineService<Customer> _customersLineService;

        public CustomersLineAdder(string description, ILineService<Customer> customersLineService)
        {
            Description = description;
            _customersLineService = customersLineService;
        }

        public void Action()
        {
            Console.WriteLine("Enter customer name:");
            string customerName = Console.ReadLine();

            Console.WriteLine($"Enter {customerName}'s body temp (c° degree):");
            if (!_tryGetCostumerTemp(out int bodyTemperature)) return;

            Console.WriteLine($"Does {customerName} wear mask? (true/false)");
            if (!_tryGetBool(out bool maskOn)) return;

            Console.WriteLine($"Does {customerName} should be isolated? (true/false)");
            if (!_tryGetBool(out bool shouldIsolate)) return;

            var customer = new Customer(customerName, bodyTemperature, maskOn, shouldIsolate);
            if (!_customersLineService.TryAddItemToLine(customer, out string failingMessage))
            {
                Console.WriteLine($"\nFailed adding customer to line. Failing reason:\n{failingMessage}\n");
                return;
            }

            Console.WriteLine($"Added customer '{customer}' to the line!\n");
        }

        private bool _tryGetCostumerTemp(out int bodyTemperature)
        {
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out bodyTemperature))
            {
                Console.WriteLine($"'{userInput}' is not a valid body temperature!\nTry again..\n");
                return false;
            }

            return true;
        }

        private bool _tryGetBool(out bool answer)
        {
            string userInput = Console.ReadLine();
            if (!bool.TryParse(userInput, out answer))
            {
                Console.WriteLine($"'{userInput}' is not true/false!\nTry again..\n");
                return false;
            }

            return true;
        }
    }
}