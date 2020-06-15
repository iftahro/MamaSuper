using System;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Prints the line details (current customers in line)
    /// </summary>
    public class LineCustomersOption : IMenuOption
    {
        private readonly ILineService _lineService;

        public LineCustomersOption(ILineService lineService)
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
            MenuUtils.PrintListAscending(_lineService.CustomersLine.GetLineItems().ToList());
            Console.WriteLine();
        }
    }
}