using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Logic.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints all the costumers that are in the line
    /// </summary>
    public class CostumerPrinter : IMenuOption
    {
        public string Description { get; }

        private readonly Line<Costumer> _costumersLine;

        public CostumerPrinter(string description, Line<Costumer> costumersLine)
        {
            Description = description;
            _costumersLine = costumersLine;
        }

        public void Action()
        {
            if (_costumersLine.CountLine() == 0)
            {
                Console.WriteLine("There are no costumers in line yet");
                return;
            }
            
            List<Costumer> costumers = _costumersLine.GetQueueItems().ToList();
            Console.WriteLine("Costumers list:");
            costumers.ForEach(costumer => Console.WriteLine(costumer.Name));
        }
    }
}