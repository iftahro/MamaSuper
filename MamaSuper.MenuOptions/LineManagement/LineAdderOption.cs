using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Adds new customers to the supermarket line 
    /// </summary>
    public class LineAdderOption : IMenuOption
    {
        private readonly ILineService _lineService;

        public LineAdderOption(ILineService lineService)
        {
            _lineService = lineService;
        }

        public string Description { get; } = "Add a new customer to the line";

        public void Action()
        {
            string customerName = ConsoleUtils.GetInputAfterOutput("Enter customer name:");

            string bodyTempInput = ConsoleUtils.GetInputAfterOutput($"Enter {customerName}'s body temp (c° degree):");
            if (!bodyTempInput.TryParseToInt(out int bodyTemperature)) return;

            string hasMaskInput = ConsoleUtils.GetInputAfterOutput($"Does {customerName} wear mask? (true/false)");
            if (!hasMaskInput.TryParseToBool(out bool maskOn)) return;

            string shouldIsolateInput =
                ConsoleUtils.GetInputAfterOutput($"Does {customerName} should be isolated? (true/false)");
            if (!shouldIsolateInput.TryParseToBool(out bool shouldIsolate)) return;

            string moneyInput = ConsoleUtils.GetInputAfterOutput($"Enter {customerName} amount of money (dollars $):");
            if (!moneyInput.TryParseToInt(out int customerMoney)) return;

            var customer = new Customer(customerName, bodyTemperature, maskOn, shouldIsolate, customerMoney);
            if (!customer.IsPermittedToEnter(out string failingMessage))
            {
                Console.WriteLine(
                    $"\nFailed adding customer '{customerName}' to line. Failing reason:\n{failingMessage}\n");
                return;
            }

            _lineService.CustomersLine.AddLineItem(customer);
            Console.WriteLine($"\nAdded customer '{customer}' to the line!\n");
        }
    }
}