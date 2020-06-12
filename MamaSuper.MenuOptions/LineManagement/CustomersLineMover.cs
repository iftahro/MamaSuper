using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Moves customer out of the supermarket line
    /// </summary>
    public class CustomersLineMover : IMenuOption
    {
        public string Description { get; }

        private readonly ILineService<Customer> _customersLineService;

        public CustomersLineMover(string description, ILineService<Customer> customersLineService)
        {
            Description = description;
            _customersLineService = customersLineService;
        }

        public void Action()
        {
            int lineCustomers = _customersLineService.GetLineItems().Count;
            if (lineCustomers == 0)
            {
                Console.WriteLine("There are no customer in line!");
                return;
            }

            Console.WriteLine("Enter the amount of customer to move:");
            if (!_tryGetCostumersToMove(lineCustomers, out int customersToMove)) return;

            IEnumerable<Customer> movedCostumers = _customersLineService.MoveItemsFromLine(customersToMove);
            movedCostumers.ToList().ForEach(costumer => Console.WriteLine($"Moved {costumer} from line to supermarket"));
        }

        private bool _tryGetCostumersToMove(int lineCustomers, out int customersToMove)
        {
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out customersToMove))
            {
                Console.WriteLine($"'{userInput}' is not a valid number!");
                return false;
            }

            if (customersToMove > lineCustomers)
            {
                Console.WriteLine($"There are only {lineCustomers} customer in line!");
            }

            return true;
        }
    }
}