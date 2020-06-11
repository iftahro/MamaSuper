using System;
using MamaSuper.Logic.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Adds new costumers to the supermarket line 
    /// </summary>
    public class CostumersLineAdder : IMenuOption
    {
        public string Description { get; }

        private readonly ILineService<Costumer> _costumersLineService;

        public CostumersLineAdder(string description, ILineService<Costumer> costumersLineService)
        {
            Description = description;
            _costumersLineService = costumersLineService;
        }

        public void Action()
        {
            Console.WriteLine("Enter costumer name:");
            string costumerName = Console.ReadLine();

            Console.WriteLine($"Enter {costumerName}'s body temp (c° degree):");
            if (!_tryGetCostumerTemp(out int bodyTemperature)) return;

            Console.WriteLine($"Does {costumerName} wear mask? (true/false)");
            if (!_tryGetBool(out bool maskOn)) return;

            Console.WriteLine($"Does {costumerName} should be isolated? (true/false)");
            if (!_tryGetBool(out bool shouldIsolate)) return;

            var costumer = new Costumer(costumerName, bodyTemperature, maskOn, shouldIsolate);
            if (!_costumersLineService.TryAddItemToLine(costumer, out string failingMessage))
            {
                Console.WriteLine($"\nFailed adding costumer to line. Failing reason:\n{failingMessage}\n");
                return;
            }

            Console.WriteLine($"Added costumer '{costumer}' to the line!\n");
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