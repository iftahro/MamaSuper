using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;

namespace MamaSuper.MenuOptions.CashiersManagement
{
    /// <summary>
    /// Prints all the supermarket cashiers passed customers
    /// </summary>
    public class PassedCustomersOption : IMenuOption
    {
        private readonly ICashiersService _cashiersService;

        public PassedCustomersOption(ICashiersService cashiersService)
        {
            _cashiersService = cashiersService;
        }

        public string Description { get; } = "Get cashiers passed customers";

        public void Action()
        {
            List<Cashier> cashiers = _cashiersService.GetAllCashiers().ToList();
            for (int i = 0; i < cashiers.Count; i++)
            {
                Cashier cashier = cashiers[i];
                if (!cashier.IsOpen())
                {
                    Console.WriteLine($"No.{i + 1}: No customers has passed yet\n");
                    continue;
                }

                Console.WriteLine($"No.{i + 1}: {cashier}\n");
            }
        }
    }
}