using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.LineManagement
{
    /// <summary>
    /// Moves customers out of the supermarket line
    /// </summary>
    public class LineMoverOption : IMenuOption
    {
        private readonly ILineService _lineService;

        public LineMoverOption(ILineService lineService)
        {
            _lineService = lineService;
        }

        public string Description { get; } = "Move customers into the supermarket";

        public void Action()
        {
            int currentLineCount = _lineService.CustomersLine.CountLineItems();
            if (currentLineCount == 0)
            {
                Console.WriteLine("There are no customers in line!\n");
                return;
            }

            string customersToMoveInput = ConsoleUtils.GetInputAfterOutput("Enter the amount of customer to move:");
            if (!MenuUtils.ValidateNumericMenuChoice(customersToMoveInput, 
                currentLineCount, out int customersToMove)) return;

            _lineService.MoveOutCustomers(customersToMove);
        }
    }
}