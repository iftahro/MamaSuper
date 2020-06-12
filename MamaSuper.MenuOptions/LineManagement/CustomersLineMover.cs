using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Moves customer out of the supermarket line
    /// </summary>
    public class CustomersLineMover : IMenuOption
    {
        private readonly ILineService<Customer> _customersLineService;

        public CustomersLineMover(ILineService<Customer> customersLineService)
        {
            _customersLineService = customersLineService;
        }

        public string Description { get; } = "Move customers into the supermarket";

        public void Action()
        {
            int currentLineCount = _customersLineService.CountLineItems();
            if (currentLineCount == 0)
            {
                Console.WriteLine("There are no customer in line!\n");
                return;
            }

            string customersToMoveInput = ConsoleUtils.GetInputAfterOutput("Enter the amount of customer to move:");
            if (!validateCustomersToMove(customersToMoveInput, currentLineCount, out int customersToMove)) return;

            IEnumerable<Customer> movedCostumers = _customersLineService.MoveOutItems(customersToMove);
            foreach (Customer movedCostumer in movedCostumers)
            {
                Console.WriteLine($"Moved {movedCostumer} from line to supermarket");
            }
        }

        private bool validateCustomersToMove(string customersToMoveInput, int currentLineCount, out int customersToMove)
        {
            if (!customersToMoveInput.TryParseToInt(out customersToMove)) return false;

            if (customersToMove < 0)
            {
                Console.WriteLine($"'{customersToMove}' is not a valid customers amount!\n");
                return false;
            }

            if (customersToMove > currentLineCount)
            {
                Console.WriteLine($"There are only {currentLineCount} customers in the line!\n");
                return false;
            }

            return true;
        }
    }
}