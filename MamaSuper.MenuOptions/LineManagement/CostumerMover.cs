using System;
using MamaSuper.Logic.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Moves costumers into the supermarket
    /// </summary>
    public class CostumerMover : IMenuOption
    {
        public string Description { get; }

        private readonly Line<Costumer> _costumersLine;

        public CostumerMover(string description, Line<Costumer> costumersLine)
        {
            Description = description;
            _costumersLine = costumersLine;
        }

        public void Action()
        {
            if (_costumersLine.CountLine() == 0)
            {
                Console.WriteLine("There are no costumers in line yet!");
                return;
            }
            
            Console.WriteLine("Enter the amount of costumers to move:");
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out int customersAmount))
            {
                Console.WriteLine($"'{userInput}' is not a valid number!");
                return;
            }
            
            for (int i = 0; i < customersAmount; i++)
            {
                Costumer costumer = _costumersLine.RemoveFromLine();
                Console.WriteLine($"Moved '{costumer.Name}' into the super");
            }
        }
    }
}