using System;
using System.Collections.Generic;
using MamaSuper.Logic.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints all costumers in line
    /// </summary>
    public class CostumersLinePrinter : IMenuOption
    {
        public string Description { get; }

        private readonly ILineService<Costumer> _costumersLineService;

        public CostumersLinePrinter(string description, ILineService<Costumer> costumersLineService)
        {
            Description = description;
            _costumersLineService = costumersLineService;
        }

        public void Action()
        {
            IList<Costumer> currentLineCostumers = _costumersLineService.GetLineItems();
            if (currentLineCostumers.Count == 0)
            {
                Console.WriteLine("There are no costumers in line");
                return;
            }

            Console.WriteLine("Current costumers in line:");
            foreach (Costumer costumer in currentLineCostumers)
            {
                Console.WriteLine(costumer);
            }
        }
    }
}