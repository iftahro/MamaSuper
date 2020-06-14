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

        public CashiersService(List<Cashier> cashiers, ILineService lineService, 
            Dictionary<string, int> supermarketProducts)
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
            Cashier emptiestCashier = getEmptiestCashier();
            if (emptiestCashier == null)
            {
                _lineService.CustomersLine.AddLineItem(customer);
                Console.WriteLine($"No workers in the supermarket. Customer '{customer}' sent back to the line\n");
                return;
            }

            List<Product> randomProducts = ProductUtils.GenerateRandomProducts(_supermarketProducts);
            registerCustomer(customer, emptiestCashier, randomProducts);
            Console.WriteLine($"Customer '{customer}' has registered in the cashiers successfully!\n");
        }

        /// <summary>
        /// Returns the emptiest supermarket cashier
        /// </summary>
        private Cashier getEmptiestCashier()
        {
            List<Cashier> availableCashiers = Cashiers.FindAll(cashier => cashier.IsOpen);
            if (availableCashiers.Count == 0) return null;

            for (int i = 0; i < availableCashiers.Count; i++)
            {
                if (i == availableCashiers.Count - 1) break;
                if (availableCashiers[i].Registers.Count > availableCashiers[i + 1].Registers.Count)
                {
                    return availableCashiers[i + 1];
                }
            }

            return availableCashiers[0];
        }

        /// <summary>
        /// Registers customer in a cashier 
        /// </summary>
        /// <param name="customer">The customer who registers</param>
        /// <param name="cashier">The cashier to be registered in</param>
        /// <param name="products">The costumer's products to buy</param>
        private void registerCustomer(Customer customer, Cashier cashier, List<Product> products)
        {
            if (cashier.Registers.Count == 0)
            {
                cashier.DateOpened = DateTime.Now;
            }

            cashier.Registers[customer] = products;
        }
    }
}