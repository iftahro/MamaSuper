using System;
using System.Collections.Generic;
using System.Linq;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.MenuOptions.CashiersManagement
{
    /// <summary>
    /// Prints all the supermarket cashiers registers
    /// </summary>
    public class RegistersOption : IMenuOption
    {
        private readonly ICashiersService _cashiersService;

        public RegistersOption(ICashiersService cashiersService)
        {
            _cashiersService = cashiersService;
        }

        public string Description { get; } = "Get cashiers registers";

        public void Action()
        {
            List<Cashier> cashiers = _cashiersService.GetAllCashiers().ToList();
            for (int i = 0; i < cashiers.Count; i++)
            {
                Cashier cashier = cashiers[i];
                if (!cashier.IsOpen())
                {
                    Console.WriteLine($"\nNo.{i + 1}: No registers yet\n");
                    continue;
                }

                Console.WriteLine($"\nCashier No.{i + 1}:");
                foreach ((Customer customer, List<Product> products) in cashier.Registers)
                {
                    Console.WriteLine($"{customer}- {ProductUtils.DictionaryRepresentation(products)}");
                }
            }
        }
    }
}