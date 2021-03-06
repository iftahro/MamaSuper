﻿using System;
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
    public class CashiersRegistersOption : IMenuOption
    {
        private readonly ICashiersService _cashiersService;

        public CashiersRegistersOption(ICashiersService cashiersService)
        {
            _cashiersService = cashiersService;
        }

        public string Description { get; } = "Get all cashiers registers";

        public void Action()
        {
            List<Cashier> cashiers = _cashiersService.Cashiers.ToList();
            for (int i = 0; i < cashiers.Count; i++)
            {
                Cashier cashier = cashiers[i];
                string cashierRepresentation = $"Cashier No.{i + 1} ({cashier.Worker})";

                if (cashier.Registers.Count == 0)
                {
                    Console.WriteLine($"\n{cashierRepresentation}: No registers yet\n");
                    continue;
                }

                Console.WriteLine($"\n{cashierRepresentation}:");
                foreach ((Customer customer, List<Product> products) in cashier.Registers)
                {
                    Dictionary<string, int> productsByName = ProductUtils.GroupProductsByName(products);
                    Console.WriteLine($"{customer}- {string.Join(",", productsByName)}");
                }
            }
        }
    }
}