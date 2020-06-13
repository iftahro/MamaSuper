using System;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.ExtensionMethods;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.CashiersManagement
{
    /// <summary>
    /// Isolates retrospectively all customers of a specific cashier
    /// </summary>
    public class CashierIsolationOption : IMenuOption
    {
        private readonly ICashiersService _cashiersService;
        private readonly PassedCustomersOption _passedCustomersOption;

        public CashierIsolationOption(ICashiersService cashiersService, PassedCustomersOption passedCustomersOption)
        {
            _cashiersService = cashiersService;
            _passedCustomersOption = passedCustomersOption;
        }

        public string Description { get; } = "Isolate cashier customers retrospectively";

        public void Action()
        {
            _passedCustomersOption.Action();
            string userInput = ConsoleUtils.GetInputAfterOutput("Choose a cashier:");
            if (!validateUserChoice(userInput, out int userChoice)) return;

            Cashier chosenCashier = _cashiersService.Cashiers[userChoice - 1];
            if (!chosenCashier.IsOpen())
            {
                Console.WriteLine("No customers passed in that cashier yet!\n");
                return;
            }

            foreach (Customer customer in chosenCashier.PassedCustomers)
            {
                customer.ShouldIsolate = true;
            }

            Console.WriteLine($"Cashier No.{userChoice} customers ({chosenCashier}) are now isolated\n");
        }

        private bool validateUserChoice(string userInput, out int userChoice)
        {
            if (!userInput.TryParseToInt(out userChoice)) return false;

            if (userChoice <= 0 || userChoice > _cashiersService.Cashiers.Count)
            {
                Console.WriteLine($"'{userChoice}' is not in cashiers range!\n");
                return false;
            }

            return true;
        }
    }
}