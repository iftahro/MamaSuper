using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.CashiersManagement
{
    /// <summary>
    /// Isolates retrospectively all customers of a specific cashier
    /// </summary>
    public class CashierIsolationOption : IMenuOption
    {
        private readonly ICashiersService _cashiersService;

        public CashierIsolationOption(ICashiersService cashiersService)
        {
            _cashiersService = cashiersService;
        }

        public string Description { get; } = "Isolate cashier retrospectively";

        public void Action()
        {
            string userInput = ConsoleUtils.GetInputAfterOutput($"Choose a cashier to isolate (1-{_cashiersService.Cashiers.Count}):");
            if (!MenuUtils.ValidateNumericMenuChoice(userInput, _cashiersService.Cashiers.Count, out int userChoice)) return;

            Cashier chosenCashier = _cashiersService.Cashiers[userChoice - 1];
            if (chosenCashier.Registers.Count == 0)
            {
                Console.WriteLine("No customers passed in this cashier yet!\n");
                return;
            }

            if (chosenCashier.Worker.ShouldIsolate)
            {
                Console.WriteLine("Already isolated this cashier!");
                return;
            }

            foreach (Customer customer in chosenCashier.Registers.Keys) 
                customer.ShouldIsolate = true;

            chosenCashier.Worker.ShouldIsolate = true;
            chosenCashier.IsOpen = false;

            Console.WriteLine($"Cashier No.{userChoice} customers ({chosenCashier}) and its worker " +
                              $"({chosenCashier.Worker}) are now isolated\n");
        }
    }
}