using System;
using System.Collections.Generic;
using MamaSuper.Common.Interfaces;
using MamaSuper.Common.Models;
using MamaSuper.Logic.Utils;

namespace MamaSuper.Logic.Services
{
    /// <summary>
    /// <inheritdoc cref="ICashiersService"/>
    /// </summary>
    public class CashiersService : ICashiersService
    {
        private readonly Dictionary<string, int> _supermarketProducts;
        private readonly ILineService _lineService;

        public CashiersService(List<Cashier> cashiers, ILineService lineService, Dictionary<string, int> supermarketProducts)
        {
            Cashiers = cashiers;
            _supermarketProducts = supermarketProducts;
            _lineService = lineService;
            _lineService.CustomerMovedOut += OnCustomerEnters;
        }

        /// <summary>
        /// <inheritdoc cref="ICashiersService.Cashiers"/>
        /// </summary>
        public List<Cashier> Cashiers { get; }

        /// <summary>
        /// <inheritdoc cref="ICashiersService.OnCustomerEnters"/>
        /// </summary>
        public void OnCustomerEnters(object sender, Customer customer)
        {
            Cashier cashier = getEmptiestOpenCashier();
            if (cashier == null)
            {
                _lineService.CustomersLine.AddLineItem(customer);
                Console.WriteLine($"The supermarket is close (no workers). Customer '{customer}' sent back to the line\n");
                return;
            }

            List<Product> randomProducts = ProductUtils.GenerateRandomProducts(_supermarketProducts);
            cashier.Registers[customer] = randomProducts;
            Console.WriteLine($"Customer '{customer}' has entered to the supermarket\n");
        }

        /// <summary>
        /// Returns the emptiest open supermarket cashier
        /// </summary>
        private Cashier getEmptiestOpenCashier()
        {
            List<Cashier> openCashiers = Cashiers.FindAll(cashier => cashier.IsOpen);
            if (openCashiers.Count == 0) return null;

            for (int i = 0; i < openCashiers.Count; i++)
            {
                if (i == openCashiers.Count - 1) break;
                if (openCashiers[i].Registers.Count > openCashiers[i + 1].Registers.Count)
                {
                    return openCashiers[i + 1];
                }
            }

            return openCashiers[0];
        }
    }
}