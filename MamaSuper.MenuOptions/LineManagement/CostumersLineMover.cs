using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Logic.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Moves costumers out of the supermarket line
    /// </summary>
    public class CostumersLineMover : IMenuOption
    {
        public string Description { get; }

        private readonly ILineService<Costumer> _costumersLineService;

        public CostumersLineMover(string description, ILineService<Costumer> costumersLineService)
        {
            Description = description;
            _costumersLineService = costumersLineService;
        }

        public void Action()
        {
            int lineCustomers = _costumersLineService.GetLineItems().Count;
            if (lineCustomers == 0)
            {
                Console.WriteLine("There are no costumers in line!");
                return;
            }

            Console.WriteLine("Enter the amount of costumers to move:");
            if (!_tryGetCostumersToMove(lineCustomers, out int customersToMove)) return;

            IEnumerable<Costumer> movedCostumers = _costumersLineService.MoveItemsFromLine(customersToMove);
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
                Console.WriteLine($"There are only {lineCustomers} costumers in line!");
            }

            return true;
        }
    }
}