using System;
using System.Linq;
using MamaSuper.Common.Interfaces;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints the line details (current customers in line)
    /// </summary>
    public class LineDetailsOption : IMenuOption
    {
        private readonly ILineService _lineService;

        public LineDetailsOption(ILineService lineService)
        {
            _lineService = lineService;
        }

        public string Description { get; } = "Print all customers in line";

        public void Action()
        {
            if (_lineService.CustomersLine.CountLineItems() == 0)
            {
                Console.WriteLine("There are no customers in line\n");
                return;
            }

            Console.WriteLine("Current customers in line:");
            _lineService.CustomersLine.GetLineItems().ToList().ForEach(Console.WriteLine);
        }
    }
}